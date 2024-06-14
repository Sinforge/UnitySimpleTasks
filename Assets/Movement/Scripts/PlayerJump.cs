using UnityEngine;

namespace Movement.Scripts
{
    public class PlayerJump : MonoBehaviour
    {
        public float jumpForce = 5f; // Сила прыжка
        private bool isGrounded;     // Переменная для проверки, находится ли объект на земле

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
        }

        void Update()
        {
            // Проверяем, нажата ли клавиша пробел и находится ли объект на земле
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }

        void Jump()
        {
            // Применяем силу прыжка по оси Y
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Устанавливаем, что объект в воздухе
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Проверяем, соприкасается ли объект с землей
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }
}