using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private Player _player;
    private int _damage;
    public BoxCollider2D boxCollider;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _damage = _player.Data.AttackDamage;
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _player.Attack(_damage);
        }
        else
        {
            return;
        }
    }
}
