using Units;
using UnityEngine;

namespace Enemies
{


    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float attackDamage = 10f;
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float detectionRange = 10f;
        [SerializeField] private float speed = 3f;

        private PlayerHealth _player;
        private bool _isPlayerDetected;

        public void Initialize(PlayerHealth player)
        {
            _player = player;
        }

        private void Update()
        {
            DetectPlayer();
            HandleAttack();
            Move();
        }

        private void DetectPlayer()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _player.gameObject.transform.position);
            _isPlayerDetected = distanceToPlayer <= detectionRange;
        }

        private void HandleAttack()
        {
            if (_isPlayerDetected && IsPlayerWithinAttackRange())
            {
                Attack();
            }
        }

        private bool IsPlayerWithinAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _player.gameObject.transform.position);
            return distanceToPlayer <= attackRange;
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.gameObject.transform.position,
                speed * Time.deltaTime);
        }

        private void Attack()
        {
            _player.TakeDamage(attackDamage);
        }
    }
}