using System;
using Mechanics.Damage;
using UnityEngine;

namespace Mechanics.Healths
{
    public class Health : MonoBehaviour, IHealth, IDamageable
    {
        public event Action Dead;
        public float MaxHealth { get; set; } = 100f;
        private float _currentHealth;

        public void Initialize()
        {
            _currentHealth = MaxHealth;
        }

        public void TakeDamage(float damage, object sender)
        {
            _currentHealth -= damage;
            CheckDeath(_currentHealth);
            Debug.Log($"Damage with {sender.GetType().Name}");

        }
        
        private void CheckDeath(float health)
        {
            if (health < 0f)
            {
                Die();
            }
        }
        
        public void Die()
        {
            Destroy(gameObject);
            Dead?.Invoke();
        }
    }
}
