using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    private Collider2D[] _collider2DArray;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (_stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Vector3 position = new Vector3(-0.25f, 0.5f, 0);
        _collider2DArray = Physics2D.OverlapCircleAll(_stateMachine.Player.transform.position + position, 1f, 1 << 7);

        if (_collider2DArray.Length > 0)
        {
            _stateMachine.IsAttacking = true;

            AttackCollider attackCollider = _stateMachine.Player.GetComponentInChildren<AttackCollider>();
            SpriteRenderer spriteRenderer = _stateMachine.Player.GetComponentInChildren<SpriteRenderer>();

            foreach (var col in _collider2DArray)
            {
                col.GetComponent<Collider2D>();

                if (col.transform.position.x < _stateMachine.Player.transform.position.x)
                {
                    spriteRenderer.flipX = true;
                    attackCollider.boxCollider.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else
                {
                    spriteRenderer.flipX = false;
                    attackCollider.boxCollider.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
        }
        else
        {
            _stateMachine.IsAttacking = false;
        }
    }

    protected virtual void OnAttack()
    {
        _stateMachine.ChangeState(_stateMachine.AttackState);
    }
}
