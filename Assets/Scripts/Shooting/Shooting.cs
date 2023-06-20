using UnityEngine;

namespace Mechanics.Shooting
{


    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Transform _gunBarrel; // Точка виходу кулі
        [SerializeField] private float _shootDistance = 100f; // Максимальна відстань стрільби
        [SerializeField] private LayerMask _shootableLayers; // Шари, по яких можна стріляти
        [SerializeField] private Transform _aimTransform; // Трансформ прицілу

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Aim();

            if (Input.GetButtonDown("Fire1")) // Перевірка натискання кнопки вогню (ліва кнопка миші або пробіл)
            {
                Shoot();
            }
        }

        private void Aim()
        {
            // Отримання позиції миші у світових координатах
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, _shootDistance, _shootableLayers))
            {
                // Оновлення позиції прицілу
                _aimTransform.position = hit.point;

                // Напрямок стрільби в бік прицілу
                Vector3 direction = hit.point - _gunBarrel.position;
                _gunBarrel.rotation = Quaternion.LookRotation(direction);
            }
        }

        private void Shoot()
        {
            Ray ray = new Ray(_gunBarrel.position, _gunBarrel.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _shootDistance, _shootableLayers))
            {
                if (hit.collider.GetComponent<EnemyHealth>())
                {
                    hit.collider.GetComponent<EnemyHealth>().TakeDamage(50f);
                }
            }
            else
            {
                Debug.Log("Промах");
            }
        }
    }
}