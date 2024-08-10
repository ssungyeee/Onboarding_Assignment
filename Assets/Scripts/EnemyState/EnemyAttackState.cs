using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAttackState : EnemyBaseState
{
    // 공격 상태에 진입하면 애니메이션 재생
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_enemyStateMachine.Enemy.AnimationData.AttackParameterHash);

    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_enemyStateMachine.Enemy.AnimationData.AttackParameterHash);

    }

    public override void Update()
    {
        base.Update();

        AnimatorStateInfo currentInfo = _enemyStateMachine.Enemy.Animator.GetCurrentAnimatorStateInfo(0);
        float normalizedTime = currentInfo.normalizedTime;

        if (normalizedTime >= 1f)
        {
            _enemyStateMachine.ChangeState(_enemyStateMachine.EnemyIdleState);
            //_enemyStateMachine.Enemy.AttackCollider.boxCollider.enabled = false;
        }
        else
        {
            //_enemyStateMachine.Enemy.AttackCollider.boxCollider.enabled = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
