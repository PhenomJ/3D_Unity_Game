using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State {
    Vector3 _velocity;
    public override void Start()
    {
        _character.SetAnimationTrigger("Move");
    }

    public override void Update()
    {
        if (_character.IsSetPosition())
        {
            _character.ChangeState(Character.eState.MOVE);
            return;
        }

        if (_character.GetTargetObj() == null)
        {
            _character.StopChase();
            return;
        }

        if (_character.GetTargetObj() == null)
            return;

        //Vector3 destination = _character.GetTargetPosition();
        Vector3 destination = _character.GetTargetObj().transform.position;
        destination.y = _character.GetPosition().y;
        //destination.y = _character.GetTargetObj().transform.position.y;
        Vector3 snapGround = Vector3.zero;
        Vector3 direction = (destination - _character.GetPosition()).normalized;

        _velocity = direction * 6.0f;

        if (_character.isGround())
            snapGround = Vector3.down;

        float distance = Vector3.Distance(destination, _character.GetPosition());

        

        if (distance > _character.GetAttackRange())
        {
            _character.Rotate(direction);
            _character.Move(_velocity * Time.deltaTime + snapGround);
        }

        else if (_character.IsSearchRange(distance))
        {
            _character.SetTargetObj(null);
        }

        else
        {
            _character.ChangeState(Player.eState.ATTACK);
        }
    }
}
