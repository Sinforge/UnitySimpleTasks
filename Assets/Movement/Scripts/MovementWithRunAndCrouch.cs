using UnityEngine;

namespace Movement.Scripts
{
    public class MovementWithRunAndCrouch : MonoBehaviour
    { public float walkSpeed = 5f; // Обычная скорость
    public float runSpeed = 10f; // Скорость бега
    public float crouchSpeed = 2f; // Скорость при приседании
    public float crouchHeight = 1f; // Высота при приседании
    public float normalHeight = 2f; // Нормальная высота
    public float checkDistance = 1.1f; // Дистанция проверки препятствий над игроком
    public LayerMask groundLayer; // Слой земли для проверки коллизий

    private CharacterController characterController;
    private float currentSpeed;
    private bool isCrouching = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        Move();
        HandleRun();
        HandleCrouch();
    }

    void Move()
    {
        float moveDirectionY = characterController.velocity.y;
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    void HandleRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = isCrouching ? crouchSpeed : walkSpeed;
        }
    }

    void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                if (CanStand())
                {
                    StandUp();
                }
            }
            else
            {
                Crouch();
            }
        }
    }

    void Crouch()
    {
        characterController.height = crouchHeight;
        currentSpeed = crouchSpeed;
        isCrouching = true;
    }

    void StandUp()
    {
        characterController.height = normalHeight;
        currentSpeed = walkSpeed;
        isCrouching = false;
    }

    bool CanStand()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, checkDistance, groundLayer))
        {
            return false;
        }
        return true;
    }
    }
}