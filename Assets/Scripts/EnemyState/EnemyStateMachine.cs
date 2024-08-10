using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    public EnemyIdleState EnemyIdleState { get; }
    public EnemyChaseState EnemyChaseState { get; }
    public EnemyAttackState EnemyAttackState { get; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;

        EnemyIdleState = new EnemyIdleState(this);
        EnemyChaseState = new EnemyChaseState(this);
        EnemyAttackState = new EnemyAttackState(this);
    }
}
