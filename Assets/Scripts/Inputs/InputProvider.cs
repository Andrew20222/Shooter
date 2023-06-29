using Mechanics.Aiming;
using Mechanics.Movements;
using Mechanics.Shooting;
using UnityEngine;

namespace Inputs
{
    public class InputProvider : MonoBehaviour
    {
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";
        private const string PRIMARY_FIRE_BUTTON = "Fire1";
        private const string SECONDARY_FIRE_BUTTON = "Fire2";
        private const string HORIZONTAL_MOUSE_INPUT = "Mouse X";
        private const string VERTICAL_MOUSE_INPUT = "Mouse Y";
        
        
        private IMovable _movable;
        private Vector3 _direction;
        private Shooting _shooting;
        private Scope _scope;
        public void Initialize(IMovable movable, Shooting shooting, Scope scope)
        {
            _movable = movable;
            _shooting = shooting;
            _scope = scope;
        }

        private void SetDirectionMove()
        {
            _direction = new Vector3(Input.GetAxis(HORIZONTAL_AXIS_NAME), 0, Input.GetAxis(VERTICAL_AXIS_NAME));
            _movable.Move(_direction);
        }

        private void SetRotate()
        {
            _movable.RotateWithMouse(Input.GetAxis(HORIZONTAL_MOUSE_INPUT),Input.GetAxis(VERTICAL_MOUSE_INPUT));
        }

        private void Update()
        {
            SetDirectionMove();
            SetRotate();
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _movable.Run();
            }
            
            if (Input.GetButtonDown("Jump")) 
            {
                _movable.Jump();
            }
            
            if (Input.GetButtonDown(PRIMARY_FIRE_BUTTON))
            {
                _shooting.Shoot();
            }
            else if (Input.GetButton(SECONDARY_FIRE_BUTTON))
            {
                _scope.AimWithMouse();
            }
        }
    }
}