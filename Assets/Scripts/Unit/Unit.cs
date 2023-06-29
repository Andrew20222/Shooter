using UnityEngine;

namespace Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected float Speed;
        [SerializeField] protected float Sensitivity;
    }
}
