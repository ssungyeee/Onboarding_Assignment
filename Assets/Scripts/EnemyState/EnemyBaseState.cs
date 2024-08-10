using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine _enemyStateMachine;

    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
    }

    private Player _player = GameManager.Instance.Player;

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }
    public virtual void Update()
    {
        if (_enemyStateMachine.Enemy.IsAttacking)
        {
            Attack(_player);
            return;
        }
    }

    public virtual void PhysicsUpdate()
    {
        bool find = Physics2D.OverlapCircle(_enemyStateMachine.Enemy.transform.position, 0.6f, 1 << 6);

        if (find)
        {
            _enemyStateMachine.Enemy.IsAttacking = true;
        }
        else
        {
            _enemyStateMachine.Enemy.IsAttacking = false;
        }
    }

    protected void StartAnimation(int animationHash)
    {
        _enemyStateMachine.Enemy.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        _enemyStateMachine.Enemy.Animator.SetBool(animationHash, false);
    }

    private void Attack(Player player)
    {
        _enemyStateMachine.ChangeState(_enemyStateMachine.EnemyAttackState);
    }
}
