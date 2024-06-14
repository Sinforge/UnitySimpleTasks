using UnityEngine;
using System;
using System.Collections;

namespace MovementCharacterController
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement Params")] 
        [SerializeField] public float Speed;
        [SerializeField] private Vector3 characterVelocity;

    
        private CharacterController _controller;
        void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            characterVelocity =
                transform.right * input.x * Speed +
                transform.up * characterVelocity.y +
                transform.forward * input.y * Speed;

            _controller.Move(characterVelocity * Time.deltaTime);


        }
    }
}
