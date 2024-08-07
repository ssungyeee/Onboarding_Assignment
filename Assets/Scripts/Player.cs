using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    public PlayerAnimationData AnimationData { get; private set; } = new PlayerAnimationData();
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    private void Awake()
    {
        GameManager.Instance.player = this;

        AnimationData.Initialize();
    }
}
