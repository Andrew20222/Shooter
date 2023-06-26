using System;
using UnityEngine;

public interface IHealth
{
    float MaxHealth { get; set; }
    void TakeDamage(float damage, object sender, Action<bool> callback);
    void Die(Action<bool> callback);
}
