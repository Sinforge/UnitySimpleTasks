using Unity.AI.Navigation;
using UnityEngine;

namespace NavMesh
{
    public class DynamicNavMesh : MonoBehaviour
    {
        public NavMeshSurface navMeshSurface;

        void Start()
        {
            navMeshSurface.BuildNavMesh();
        }

        void Update()
        {
            // Динамическое обновление NavMesh по требованию
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Build NavMesh");
                navMeshSurface.BuildNavMesh();
            }
        }
    }
}
