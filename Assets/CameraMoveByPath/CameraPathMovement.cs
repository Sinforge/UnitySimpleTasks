using UnityEngine;

namespace CameraMoveByPath
{
    public class CameraPathMovement : MonoBehaviour
    {
        public Transform[] pathPoints;  // Массив контрольных точек
        public float duration = 5f;     // Время прохождения всей траектории
        public AnimationCurve curve;    // Кривая анимации для сглаживания движения

        private float timeElapsed = 0f; // Время, прошедшее с начала движения

        void Update()
        {
            if (pathPoints.Length < 2)
            {
                Debug.LogError("Необходимо задать как минимум две контрольные точки.");
                return;
            }

            // Увеличиваем прошедшее время
            timeElapsed += Time.deltaTime;

            // Вычисляем нормализованное время
            float t = timeElapsed / duration;
            t = Mathf.Clamp01(t);  // Ограничиваем значение t от 0 до 1

            // Вычисляем позицию камеры по траектории
            Vector3 position = GetPointOnPath(t);
            transform.position = position;

            // Опционально: Поворот камеры по направлению движения
            if (t < 1f)
            {
                Vector3 direction = (GetPointOnPath(t + 0.01f) - position).normalized;
                if (direction != Vector3.zero)
                    transform.rotation = Quaternion.LookRotation(direction);
            }
        }

        Vector3 GetPointOnPath(float t)
        {
            int pointCount = pathPoints.Length - 1;
            int currentPoint = Mathf.FloorToInt(t * pointCount);
            float pointT = (t * pointCount) - currentPoint;

            Vector3 startPoint = pathPoints[currentPoint].position;
            Vector3 endPoint = pathPoints[currentPoint + 1].position;

            // Применение кривой анимации для сглаживания движения
            pointT = curve.Evaluate(pointT);

            return Vector3.Lerp(startPoint, endPoint, pointT);
        }
        
    }
}