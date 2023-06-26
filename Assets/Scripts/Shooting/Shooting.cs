using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Mechanics.Shooting
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Transform _gunBarrel; 
        [SerializeField] private float _shootDistance = 100f; 
        [SerializeField] private LayerMask _shootableLayers; 
        [SerializeField] private Transform _aimTransform; 
        public Action<bool> isShoot;

        public void Shoot()
        {
            Ray ray = new Ray(_gunBarrel.position, _gunBarrel.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _shootDistance, _shootableLayers))
            {
                if (hit.collider.GetComponent<Health>())
                {
                    hit.collider.GetComponent<IHealth>().TakeDamage(50f,gameObject,isShoot);
                }
            }
            else
            {
                Debug.Log("Промах");
            }
        }
    }
}