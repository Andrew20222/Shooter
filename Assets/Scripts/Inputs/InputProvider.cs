using Mechanics.Movements;
using UnityEngine;

namespace Units
{
    public class InputProvider : MonoBehaviour
    {
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";
        
        private IMovable _movable;
        private Vector3 direction;
        public void Initialize(IMovable movable)
        {
            _movable = movable;
        }
        
        private void Update()
        {
            direction = new Vector3(Input.GetAxis(HORIZONTAL_AXIS_NAME), 0, Input.GetAxis(VERTICAL_AXIS_NAME));
            _movable.Move(direction);
        }
    }
}