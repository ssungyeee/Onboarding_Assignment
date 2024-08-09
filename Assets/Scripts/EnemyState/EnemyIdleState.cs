using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyIdleState : EnemyBaseState
{
    // �ϴ� ��ȯ �� �Ϲ� ����
    // �÷��̾ ���� �پ�� ���·� ��ȯ
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

    }

    private Player _player = GameManager.Instance.Player;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_enemyStateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_enemyStateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (FindTarget(_player))
        {
            _enemyStateMachine.ChangeState(_enemyStateMachine.EnemyChaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private bool FindTarget(Player player)
    {
        Vector3 position = new Vector3(-0.25f, 0.5f, 0);
        bool find = Physics2D.OverlapCircle(_enemyStateMachine.Enemy.transform.position + position, 10f, 1 << 6);

        return find;
    }
}
