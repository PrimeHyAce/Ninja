using UnityEngine;

public class AttackState : IState
{
    private NinjaController _ninja;
    private float _attackDuration = 0.4f; // Sesuaikan dengan durasi animasi
    private float _timer;

    public AttackState(NinjaController ninja) => _ninja = ninja;

    public void Enter()
    {
        _ninja.Anim.SetTrigger("Attack");
        _ninja.Rb.linearVelocity = Vector2.zero;
        _timer = 0;
    }

    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _attackDuration)
            _ninja.StateMachine.ChangeState(new IdleState(_ninja));
    }

    public void FixedUpdate() { }
    public void Exit() { }
}