using System;
using DefaultNamespace;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public float MaxHealth { get; set; } = 100f;
    private float _currentHealth;
    public event Action<bool> isDead;

    public void Initialize()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage, object sender, Action<bool> callback)
    {
        _currentHealth -= damage;
        CheckHealthNotZero(_currentHealth);
        callback?.Invoke(true);
        Debug.Log($"Damage with {sender.GetType().Name}");

    }

    private void CheckHealthNotZero(float health)
    {
        if (health < 0f)
        {
            var objectLifecycleSystem = new ObjectLifecycleSystem();
            Die(objectLifecycleSystem.Destroyed(gameObject));
        }
    }

    public void Die(Action<bool> callback)
    {
        callback?.Invoke(true);
    }
}
