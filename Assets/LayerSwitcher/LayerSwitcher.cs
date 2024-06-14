namespace LayerSwitcher
{
    using UnityEngine;

    public class LayerSwitcher : MonoBehaviour
    {
        public string targetLayerName; // Имя слоя, на который нужно переключиться
        public KeyCode switchKey = KeyCode.L; // Клавиша для переключения слоя

        private int originalLayer; // Исходный слой объекта
        private int targetLayer; // Целевой слой

        void Start()
        {
            // Сохраняем исходный слой объекта
            originalLayer = gameObject.layer;

            // Находим индекс целевого слоя по имени
            targetLayer = LayerMask.NameToLayer(targetLayerName);

            if (targetLayer == -1)
            {
                Debug.LogError("Слой с именем " + targetLayerName + " не найден.");
            }
        }

        void Update()
        {
            // Проверяем, нажата ли клавиша переключения слоя
            if (Input.GetKeyDown(switchKey) && targetLayer != -1)
            {
                // Переключаемся между исходным и целевым слоем
                if (gameObject.layer == originalLayer)
                {
                    gameObject.layer = targetLayer;
                    Debug.Log("Объект переключен на слой: " + LayerMask.LayerToName(targetLayer));
                }
                else
                {
                    gameObject.layer = originalLayer;
                    Debug.Log("Объект переключен на исходный слой: " + LayerMask.LayerToName(originalLayer));
                }
            }
        }
    }
}