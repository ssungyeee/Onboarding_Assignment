using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    // 플레이어를 향해 뛰어가는 상태
    // 범위에 들어오면 공격 상태로 전환
    public EnemyChaseState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

    }

    private Player _player = GameManager.Instance.Player;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_enemyStateMachine.Enemy.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_enemyStateMachine.Enemy.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        MoveToTarget(_player);
    }

    private void MoveToTarget(Player player)
    {
        //float distanceToTarget = Vector3.Distance(_enemyStateMachine.Enemy.transform.position, player.transform.position);
        Vector2 DirectionToTarget = (player.transform.position - _enemyStateMachine.Enemy.transform.position).normalized;

        _enemyStateMachine.Enemy.Rigidbody2D.velocity = DirectionToTarget * _enemyStateMachine.Enemy.Data.Speed;
    }
}
