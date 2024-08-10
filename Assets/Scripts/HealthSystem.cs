using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private Enemy _enemy;

    private int _maxHealth;
    private int _health;
    private Slider _healthBar;

    public event Action OnDie;
    public bool IsDead => _health == 0;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _healthBar = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        _maxHealth = _enemy.Data.Health;
        _health = _maxHealth;
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
    }

    public void TakeDamage(int damage)
    {
        if (_health == 0) return;

        _health = Mathf.Max(_health - damage, 0);
        _healthBar.value = _health;

        if (_health == 0)
        {
            OnDie?.Invoke();
            GameManager.Instance.EnemySpwaning();
        }

        Debug.Log(_health);
    }
}
