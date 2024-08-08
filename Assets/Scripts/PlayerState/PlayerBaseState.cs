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

    public virtual void Enter()
    {
        //AddInputActionsCallbacks();
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