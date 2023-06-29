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
        private Vector3 _direction;
        private readonly float _gravityForce = Physics.gravity.y;

        public void Initialize(CharacterController characterController)
        {
            _characterController = characterController;
        }
        
        public void Move(Vector3 axis)
        {
            _direction = Vector3.zero;

            if (_characterController.isGrounded)
            {
                _direction += axis * Speed;
                _direction = transform.TransformDirection(_direction);
            }

            ApplyGravity(); 

            _characterController.Move((_direction + new Vector3(0, _verticalSpeed, 0)) * Time.deltaTime);
            
            
        }
        public void RotateWithMouse(float MouseX, float MouseY) 
        {
            float mouseX = MouseX * Sensitivity;                                                  
                                                                                                                
            transform.Rotate(0f, mouseX, 0f);                                                                       
                                                                                                                
            _rotationX -= MouseY * Sensitivity;                                                   
            _rotationX = Mathf.Clamp(_rotationX, -2.5f, 2.5f);                                                      
                                                                                                                
            transform.localRotation = Quaternion.Euler(_rotationX, transform.localRotation.eulerAngles.y, 0f);      
        }                                                                                                          
        public void Run()
        {
            _characterController.Move(_direction * (runSpeed * Time.deltaTime));
        }

        public void Jump()
        {
            if (_characterController.isGrounded)
            {
                _verticalSpeed = jumpForce;    
            }
        }
        
        private void ApplyGravity()
        {
            _verticalSpeed += _gravityForce * Time.deltaTime;
        }
    }
}