using DefaultNamespace;
using Mechanics.Movements;
using Mechanics.Shooting;
using UnityEngine;

namespace Units
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
        private Aiming _aiming;
        public void Initialize(IMovable movable, Shooting shooting, Aiming aiming)
        {
            _movable = movable;
            _shooting = shooting;
            _aiming = aiming;
        }
        
        private void Update()
        {
            _direction = new Vector3(Input.GetAxis(HORIZONTAL_AXIS_NAME), 0, Input.GetAxis(VERTICAL_AXIS_NAME));
            _movable.Move(_direction);
            _movable.RotateWithMouse(Input.GetAxis(HORIZONTAL_MOUSE_INPUT),Input.GetAxis(VERTICAL_MOUSE_INPUT));

            if (Input.GetButtonDown(PRIMARY_FIRE_BUTTON))
            {
                _shooting.Shoot();
            }
            else if (Input.GetButton(SECONDARY_FIRE_BUTTON))
            {
                _aiming.Aim();
            }
        }
    }
}