using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player _player;
    private int _damage;
    private HealthSystem _healthSystem;
    [SerializeField] private BoxCollider2D _myCollider;
    public BoxCollider2D boxCollider;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        _myCollider = _player.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _damage = _player.Data.AttackDamage;
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _myCollider) return;

        // layer 6 == Player, layer 7 == Enemy
        if (other.gameObject.layer == 7)
        {
            _healthSystem = other.gameObject.GetComponent<HealthSystem>();
            _healthSystem.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }
}
