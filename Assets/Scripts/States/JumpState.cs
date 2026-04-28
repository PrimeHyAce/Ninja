using UnityEngine;

public class JumpState : IState
{
    private NinjaController _ninja;
    public JumpState(NinjaController ninja) => _ninja = ninja;

    public void Enter()
    {
        _ninja.Anim.Play("Ninja_Jump");
        _ninja.Rb.linearVelocity = new Vector2(_ninja.Rb.linearVelocity.x, _ninja.jumpForce);
    }

    public void Update()
    {
        // Jika jatuh dan menyentuh tanah, kembali ke Idle
        if (_ninja.Rb.linearVelocity.y <= 0 && _ninja.IsGrounded())
            _ninja.StateMachine.ChangeState(new IdleState(_ninja));
    }

    public void FixedUpdate()
    {
        _ninja.Rb.linearVelocity = new Vector2(_ninja.InputX * _ninja.moveSpeed, _ninja.Rb.linearVelocity.y);
    }

    public void Exit() { }
}