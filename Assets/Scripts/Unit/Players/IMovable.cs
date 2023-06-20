using UnityEngine;

namespace Mechanics.Movements
{
    public interface IMovable
    {
        void Move(Vector3 axis);
        void Rotate();
    }
}