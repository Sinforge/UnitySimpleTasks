using UnityEngine;

namespace PrefabSpawner
{
    public class PrefabSpawner : MonoBehaviour
    {
        public GameObject prefab; // Префаб для спавна
        public float spawnRadius = 20f; // Радиус появления

        void Start()
        {
            SpawnPrefab();
        }

        void SpawnPrefab()
        {
            // Генерация случайной позиции в пределах круга
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0; // Устанавливаем y в 0, чтобы объект спавнился на плоскости

            // Спавним префаб в случайной позиции
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }
}