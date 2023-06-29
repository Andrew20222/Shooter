using System;
using UnityEngine;

namespace Mechanics.Aiming
{
    public class Scope : MonoBehaviour
    {
        public event Action UpdateAimPosition;
        [SerializeField] private float distanceToAim;
        [SerializeField] private LayerMask aimLayers;
        private Camera _camera;


        public void Initialize(Camera camera)
        {
            _camera = camera;
        }

        public void AimWithMouse()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit, distanceToAim, aimLayers))
            {
                transform.position = hit.point;
                UpdateAimPosition?.Invoke();
            }
        }
    }
}