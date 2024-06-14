using UnityEngine;

namespace Movement.Scripts
{
    public class RigidbodyMovement : MonoBehaviour
    {
        public float speed = 10f; // Скорость передвижения
        public float rotationSpeed = 100f; // Скорость вращения

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
        }

        void Update()
        {
            // Получаем ввод пользователя
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Рассчитываем вектор движения
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Применяем силу для передвижения объекта
            rb.AddForce(movement * speed);

            // Вращение объекта
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            rb.AddTorque(0, rotation, 0);
        }
    }
}