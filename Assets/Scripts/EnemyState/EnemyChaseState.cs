using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    // �÷��̾ ���� �پ�� ����
    // ������ ������ ���� ���·� ��ȯ
    public EnemyChaseState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

    }

    private Player _player = GameManager.Instance.Player;
    private SpriteRenderer spriteRenderer;
    private int _stopDistance;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_enemyStateMachine.Enemy.AnimationData.WalkParameterHash);
        spriteRenderer = _enemyStateMachine.Enemy.GetComponentInChildren<SpriteRenderer>();
        _stopDistance = 1;
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
        if (_enemyStateMachine.Enemy.transform.position.x > _player.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;

        }

        if (Vector2.Distance(_enemyStateMachine.Enemy.transform.position, player.transform.position) > _stopDistance)
        {
            _enemyStateMachine.Enemy.transform.position = Vector2.MoveTowards(_enemyStateMachine.Enemy.transform.position, player.transform.position,
                _enemyStateMachine.Enemy.Data.Speed * Time.deltaTime);
        }
    }


}
