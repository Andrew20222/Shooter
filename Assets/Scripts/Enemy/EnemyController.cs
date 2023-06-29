using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        
        private Transform _player;

        public void Initialize(Transform player)
        {
            _player = player;
        }
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position,
                speed * Time.deltaTime);
        }
    }
}