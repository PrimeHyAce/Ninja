using UnityEngine;
public class DieState : IState
{
    private NinjaController _ninja;

    public DieState(NinjaController ninja) => _ninja = ninja;

    public void Enter()
    {
        _ninja.IsDead = true;
        _ninja.Anim.SetTrigger("Die");
        _ninja.Rb.linearVelocity = Vector2.zero;
    }

    public void Update() { }
    public void FixedUpdate() { }
    public void Exit() { }
}