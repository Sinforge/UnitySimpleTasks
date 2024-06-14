using UnityEngine;

namespace Movement.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform player;        // Ссылка на объект игрока
        public Vector3 offset;          // Смещение камеры относительно игрока
        public float smoothSpeed = 0.125f; // Скорость сглаживания

        void LateUpdate()
        {
            // Целевая позиция камеры
            Vector3 desiredPosition = player.position + offset;
            // Сглаживание позиции камеры
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Установка позиции камеры
            transform.position = smoothedPosition;

            // Опционально: Поворот камеры, чтобы она всегда смотрела на игрока
            transform.LookAt(player);
        }
    }
}