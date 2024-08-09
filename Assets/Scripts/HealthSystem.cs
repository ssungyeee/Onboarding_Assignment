using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private Enemy _enemy;

    private int _maxHealth;
    private int _health;

    public event Action OnDie;
    public bool IsDead => _health == 0;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _maxHealth = _enemy.Data.Health;
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_health == 0) return;

        _health = Mathf.Max(_health - damage, 0);

        if (_health == 0)
        {
            OnDie?.Invoke();
        }

        Debug.Log(_health);
    }
}
