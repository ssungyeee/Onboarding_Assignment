using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public PlayerIdleState IdleState { get; }
    public PlayerAttackState AttackState { get; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
    }

}
