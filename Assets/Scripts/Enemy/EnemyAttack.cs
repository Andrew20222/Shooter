using Mechanics.Healths;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackDamage = 10f;
        private EnemyDetected _enemyDetected;
        private Health _player;

        public void Initialize(Health player, EnemyDetected enemyDetected)
        {
            _player = player;
            _enemyDetected = enemyDetected;
        }

        private void Update()
        {
            if (_enemyDetected.HandleAttack())
            {
                Attack();
            }
        }

        private void Attack()
        {
            _player.TakeDamage(attackDamage, this);
        }
    }
}