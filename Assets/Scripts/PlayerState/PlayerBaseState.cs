using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine _stateMachine;


    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _stateMachine = playerStateMachine;
    }

    private Collider2D[] _collider2DArray;
    private Weapon attackCollider;
    private SpriteRenderer spriteRenderer;

    public virtual void Enter()
    {
        //AddInputActionsCallbacks();
        attackCollider = _stateMachine.Player.GetComponentInChildren<Weapon>();
        spriteRenderer = _stateMachine.Player.GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Exit()
    {
        //RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {

    }

    public virtual void PhysicsUpdate()
    {
        Vector3 position = new Vector3(-0.25f, 0.5f, 0);
        _collider2DArray = Physics2D.OverlapCircleAll(_stateMachine.Player.transform.position + position, 1f, 1 << 7);

        if (_collider2DArray.Length != 0)
        {
            _stateMachine.IsAttacking = true;

            foreach (var col in _collider2DArray)
            {
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

    public virtual void Update()
    {

    }

    protected void StartAnimation(int animationHash)
    {
        _stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        _stateMachine.Player.Animator.SetBool(animationHash, false);
    }

    //protected virtual void AddInputActionsCallbacks()
    //{
    //    PlayerInput input = _stateMachine.Player.Input;

    //    input.PlayerActions.Attack.started += OnAttackStarted;
    //    input.PlayerActions.Attack.canceled += OnAttackCanceled;
    //}

    //protected virtual void RemoveInputActionsCallbacks()
    //{
    //    PlayerInput input = _stateMachine.Player.Input;

    //    input.PlayerActions.Attack.started -= OnAttackStarted;
    //    input.PlayerActions.Attack.canceled -= OnAttackCanceled;
    //}

    //protected virtual void OnAttackStarted(InputAction.CallbackContext context)
    //{
    //    _stateMachine.IsAttacking = true;
    //}

    //protected virtual void OnAttackCanceled(InputAction.CallbackContext context)
    //{
    //    _stateMachine.IsAttacking = false;
    //}
}