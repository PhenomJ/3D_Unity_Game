using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Start()
    {
        //_character.SetAnimationTrigger("Attack");
        _character.GetAnimationPlayer().Play("Attack", ()=> { Debug.Log("Start Anim"); },
        () =>
        {
            _character.AttackStart();
        },
        () =>
        {
            _character.AttackEnd();
        },
        () =>
        {
            _character.ChangeState(Character.eState.IDLE);
        });
    }

    public override void Stop()
    {
    }

    public override void Update()
    {
    }

    public override void UpdateInput()
    {
        // Combo Attack 처리
    }
}
