using UnityEngine;

public class IdleState : IState
{
    private NinjaController _ninja;

    public IdleState(NinjaController ninja) => _ninja = ninja;

    public void Enter() => _ninja.Anim.Play("Ninja_Idle"); // Nama animasi sesuai folder
    
    public void Update()
    {
        if (Mathf.Abs(_ninja.InputX) > 0.01f)
            _ninja.StateMachine.ChangeState(new RunState(_ninja));
        
        if (Input.GetKeyDown(KeyCode.Space) && _ninja.IsGrounded())
            _ninja.StateMachine.ChangeState(new JumpState(_ninja));

        if (Input.GetKeyDown(KeyCode.J))
            _ninja.StateMachine.ChangeState(new AttackState(_ninja));
    }

    public void FixedUpdate() => _ninja.Rb.linearVelocity = new Vector2(0, _ninja.Rb.linearVelocity.y);
    public void Exit() { }
}