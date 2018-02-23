using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Start()
    {
        _character.SetAnimationTrigger("Idle");
    }

    public override void Stop()
    {
        base.Stop();
    }

    public override void Update()
    {

    }

    public override void UpdateInput()
    {
        _character.ChangeState(Player.eState.MOVE);
    }
}
