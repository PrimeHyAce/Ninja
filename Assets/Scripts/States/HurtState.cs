using UnityEngine;
public class HurtState : IState
{
    private NinjaController _ninja;
    private float _timer;

    public HurtState(NinjaController ninja) => _ninja = ninja;

    public void Enter()
    {
        _ninja.Anim.SetTrigger("Hurt");
        _timer = 0.3f;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0) _ninja.StateMachine.ChangeState(new IdleState(_ninja));
    }

    public void FixedUpdate() { }
    public void Exit() { }
}