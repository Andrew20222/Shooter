using System;
using Mechanics.Movements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Units
{
    public class PlayerController : Unit, IMovable
    {
        private const float GRAVITY_FORCE = 9.81f;
        [SerializeField] private float jumpForce;
        [SerializeField] private float runSpeed = 8f;  
        
        private CharacterController _characterController;
        private float _verticalSpeed;
        private float _rotationX;

        public void Initialize()
        {
            _characterController = gameObject.GetComponent<CharacterController>();
        }
        
        public void Move(Vector3 axis)
        {
            var direction = Vector3.zero;

            if (_characterController.isGrounded)
            {
                direction += axis * Speed;
                direction = transform.TransformDirection(direction);

                if (Input.GetButtonDown("Jump")) 
                {
                    _verticalSpeed = jumpForce; 
                }
            }

            ApplyGravity(); 

            _characterController.Move((direction + new Vector3(0, _verticalSpeed, 0)) * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run(runSpeed, direction);
            }
        }
        public void Rotate() 
        {                                                                                                           
            float mouseX = Input.GetAxis("Mouse X") * Sensitivity;                                                  
                                                                                                                
            transform.Rotate(0f, mouseX, 0f);                                                                       
                                                                                                                
            _rotationX -= Input.GetAxis("Mouse Y") * Sensitivity;                                                   
            _rotationX = Mathf.Clamp(_rotationX, -2.5f, 2.5f);                                                      
                                                                                                                
            transform.localRotation = Quaternion.Euler(_rotationX, transform.localRotation.eulerAngles.y, 0f);      
        }                                                                                                          
        private void Run(float movementSpeed, Vector3 direction)
        {
            _characterController.Move(direction * (movementSpeed * Time.deltaTime));
        }
        
        private void ApplyGravity()
        {
            _verticalSpeed -= GRAVITY_FORCE * Time.deltaTime;
        }
    }
}