using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class NinjaController : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    public NinjaStateMachine StateMachine { get; private set; }

    [Header("Settings")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    // Input data
    public float InputX { get; private set; }
    public bool IsDead { get; set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        StateMachine = new NinjaStateMachine();
    }

    private void Start()
    {
        // Memulai dengan IdleState
        StateMachine.Initialize(new IdleState(this));
    }

    private void Update()
    {
        if (IsDead) return;

        InputX = Input.GetAxisRaw("Horizontal");

        Anim.SetFloat("Speed", Mathf.Abs(InputX)); // Untuk transisi animasi
        Anim.SetBool("isJumping", !IsGrounded()); // Untuk transisi animasi

        StateMachine.CurrentState.Update();
        FlipController();
    }

    private void FixedUpdate()
    {
        if (IsDead) return;
        StateMachine.CurrentState.FixedUpdate();
    }

    private void FlipController()
    {
        if (InputX > 0) transform.localScale = Vector3.one;
        else if (InputX < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Dipanggil dari trigger luar (misal: musuh)
    public void TakeDamage()
    {
        if (IsDead) return;
        StateMachine.ChangeState(new HurtState(this));
    }

    // Dipanggil dari animasi (Animation Event)
    public void Die()
    {
        if (IsDead) return;
        StateMachine.ChangeState(new DieState(this));
    }

    // on trigger hurt and die test
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hurt_Test")) // yellow triangle in game
            TakeDamage();
        else if (collision.gameObject.CompareTag("Die_Test")) // red triangle in game
             Die();
    }
}