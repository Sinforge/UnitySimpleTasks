using System;
using UnityEngine;

namespace MovementCharacterController
{

    public class CameraMovement: MonoBehaviour
    {
        #region mouse settings
        [Header("Mouse Sense")]
        [SerializeField] private float MouseSenseX;
        [SerializeField] private float MouseSenseY;
        #endregion

        private Camera _camera;
        public void Start()
        {
            _camera = GetComponentInChildren<Camera>();
        }
        public void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSenseX * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSenseY * Time.deltaTime;

            
            transform.Rotate(Vector3.up * mouseX);
            _camera.transform.Rotate(Vector3.left * mouseY);
        }
    }
}