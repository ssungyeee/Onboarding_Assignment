using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Rigidbody2D Rigidbody2D { get; private set; }
    public Animator Animator { get; private set; }
    public HealthSystem HealthSystem { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();

        Initializable();

        StateMachine = new EnemyStateMachine(this);
    }

    private void Initializable()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
        HealthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.EnemyIdleState);
        HealthSystem.OnDie += Death;
    }

    public void Update()
    {
        StateMachine.HandleInput();
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }

    private void Death()
    {
        Debug.Log("Death");
    }

    private void OnDrawGizmos()
    {
        Vector3 position = new Vector3(-0.25f, 0.5f, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + position, 10f);
    }
}
