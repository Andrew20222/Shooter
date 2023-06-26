using Mechanics.Movements;
using UnityEngine;

namespace Units
{
    public class PlayerController : Unit, IMovable
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private float runSpeed = 8f;  
        
        private CharacterController _characterController;
        private float _verticalSpeed;
        private float _rotationX;
        private float _gravityForce = Physics.gravity.y;

        public void Initialize(CharacterController characterController)
        {
            _characterController = characterController;
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
                    Jump();
                }
            }

            ApplyGravity(); 

            _characterController.Move((direction + new Vector3(0, _verticalSpeed, 0)) * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run(runSpeed, direction);
            }
        }
        public void RotateWithMouse(float MouseX, float MouseY) 
        {
            float mouseX = MouseX * Sensitivity;                                                  
                                                                                                                
            transform.Rotate(0f, mouseX, 0f);                                                                       
                                                                                                                
            _rotationX -= MouseY * Sensitivity;                                                   
            _rotationX = Mathf.Clamp(_rotationX, -2.5f, 2.5f);                                                      
                                                                                                                
            transform.localRotation = Quaternion.Euler(_rotationX, transform.localRotation.eulerAngles.y, 0f);      
        }                                                                                                          
        public void Run(float movementSpeed, Vector3 direction)
        {
            _characterController.Move(direction * (movementSpeed * Time.deltaTime));
        }

        public void Jump()
        {
            _verticalSpeed = jumpForce;
        }
        
        private void ApplyGravity()
        {
            _verticalSpeed += _gravityForce * Time.deltaTime;
        }
    }
}