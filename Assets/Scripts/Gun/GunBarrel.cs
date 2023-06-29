using Mechanics.Aiming;
using UnityEngine;

namespace Guns.Barrels
{
    public class GunBarrel : MonoBehaviour
    {
        private Scope _scope;

        public void Initialize(Scope scope)
        {
            _scope = scope;
            _scope.UpdateAimPosition += Rotate;
        }

        private void Rotate()
        {
            var direction = _scope.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        private void OnDisable()
        {
            _scope.UpdateAimPosition -= Rotate;
        }
    }
}
