using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    public PlayerAnimationData AnimationData { get; private set; } = new PlayerAnimationData();
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public AttackCollider AttackCollider { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerInput Input { get; private set; }

    private void Awake()
    {
        GameManager.Instance.player = this;

        AnimationData.Initialize();

        SetComponents();

        StateMachine = new PlayerStateMachine(this);
    }

    private void SetComponents()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        AttackCollider = GetComponentInChildren<AttackCollider>();
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.IdleState);
    }

    private void Update()
    {
        StateMachine.HandleInput();
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }

    public void Attack(int damage)
    {
        // damage ��ŭ EnemyData�� ����
        Debug.Log("atk");
    }

    private void OnDrawGizmos()
    {
        Vector3 position = new Vector3(-0.25f, 0.5f, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + position, 1f);
    }
}
