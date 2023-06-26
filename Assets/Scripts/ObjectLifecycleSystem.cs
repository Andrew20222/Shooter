using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectLifecycleSystem : MonoBehaviour
    {
        private Health _health;
        public Action<bool> isDead;

        public Action<bool> Destroyed(GameObject destroyedGameObject)
        {
            Destroy(destroyedGameObject);
            return isDead;
        }
    }
}