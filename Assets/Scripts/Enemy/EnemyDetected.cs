using UnityEngine;

namespace Enemies
{
    public class EnemyDetected : MonoBehaviour
    {
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float detectionRange = 10f;
        

        private Transform _player;
        private bool _isPlayerDetected;

        public void Initialize(Transform player)
        {
            _player = player;
        }

        public bool HandleAttack()
        {
            if (_isPlayerDetected && IsPlayerWithinAttackRange())
            {
                return true;
            }

            return false;
        }

        private void Update()
        {
            DetectPlayer();
        }

        private void DetectPlayer()
        {
            var distanceToPlayer = Vector3.Distance(transform.position, _player.position);
            _isPlayerDetected = distanceToPlayer <= detectionRange;
        }

        private bool IsPlayerWithinAttackRange()
        {
            var distanceToPlayer = Vector3.Distance(transform.position, _player.position);
            return distanceToPlayer <= attackRange;
        }
    }
}