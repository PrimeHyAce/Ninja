using UnityEngine;

public class RunState : IState
{
    private NinjaController _ninja;
    public RunState(NinjaController ninja) => _ninja = ninja;

    public void Enter() => _ninja.Anim.Play("Ninja_Run"); // Sesuai nama di Animator Anda

    public void Update()
    {
        // Jika berhenti, kembali ke Idle
        if (Mathf.Abs(_ninja.InputX) < 0.01f)
            _ninja.StateMachine.ChangeState(new IdleState(_ninja));

        if (Input.GetKeyDown(KeyCode.Space) && _ninja.IsGrounded())
            _ninja.StateMachine.ChangeState(new JumpState(_ninja));
    }

    public void FixedUpdate()
    {
        _ninja.Rb.linearVelocity = new Vector2(_ninja.InputX * _ninja.moveSpeed, _ninja.Rb.linearVelocity.y);
    }

    public void Exit() { }
}