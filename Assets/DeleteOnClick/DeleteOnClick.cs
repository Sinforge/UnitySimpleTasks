using UnityEngine;

namespace DeleteOnClick
{
    public class DeleteOnClick : MonoBehaviour
    {
        void Update()
        {
            // Проверка нажатия левой кнопки мыши
            if (Input.GetMouseButtonDown(0))
            {
                // Создание луча из камеры к позиции курсора мыши
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Проверка попадания луча в объект
                if (Physics.Raycast(ray, out hit))
                {
                    // Удаление объекта, если у него есть компонент DeleteOnClick
                    if (hit.transform.GetComponent<DeleteOnClick>() != null)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}