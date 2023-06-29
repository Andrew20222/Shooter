using Mechanics.Damage;
using UnityEngine;
using Pools;

namespace Mechanics.Shooting
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Transform _gunBarrel;
        [SerializeField] private float _shootDistance = 100f;
        [SerializeField] private LayerMask _shootableLayers;
        [SerializeField] private int poolCount;
        [SerializeField] private bool autoExpand;
        
        private ObjectPool<Ray> _rayPool;

        public void Initialize()
        {
            _rayPool = new ObjectPool<Ray>(() => new Ray(), poolCount, autoExpand);
        }

        public void Shoot()
        {
            Ray ray = _rayPool.Get();

            ray.origin = _gunBarrel.position;
            ray.direction = _gunBarrel.forward;

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _shootDistance, _shootableLayers))
            {
                if (hit.collider.GetComponent<IDamageable>() != null)
                {
                    hit.collider.GetComponent<IDamageable>().TakeDamage(50f, gameObject);
                }
            }

            _rayPool.Return(ray);
        }
    }
}
