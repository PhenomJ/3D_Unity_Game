using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Start()
    {
        _character.SetAnimationTrigger("Idle");
    }

    public override void Update()
    {
        if (_character.IsSetPosition())
        {
            _character.ChangeState(Player.eState.MOVE);
        }
    }
}
