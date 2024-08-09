using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(_stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        AnimatorStateInfo currentInfo = _stateMachine.Player.Animator.GetCurrentAnimatorStateInfo(0);
        float normalizedTime = currentInfo.normalizedTime;

        if (normalizedTime >= 1f)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
            _stateMachine.Player.AttackCollider.boxCollider.enabled = false;
        }
        else
        {
            _stateMachine.Player.AttackCollider.boxCollider.enabled = true;
        }
    }
}
