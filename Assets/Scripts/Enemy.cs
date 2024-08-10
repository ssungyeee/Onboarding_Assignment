using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
    public bool IsAttacking { get; set; }

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
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 10f);
    }
}
