using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State {
    Vector3 _destination;
    Vector3 _velocity;

    public override void Start()
    {
        _character.ArriveDestination();
        _destination = _character.GetTargetPosition();
    }

    public override void Stop()
    {

    }

    public override void Update()
    {
        _destination.y = _character.GetPosition().y;
        Vector3 snapGround = Vector3.zero;
        Vector3 direction = (_destination - _character.GetPosition()).normalized;

        _velocity = direction * 6.0f;

        if (_character.isGround())
            snapGround = Vector3.down;

        float distance = Vector3.Distance(_destination, _character.GetPosition());

        if (distance > 0.5f)
        {
            _character.Rotate(direction);
            _character.Move(_velocity * Time.deltaTime + snapGround);
            _character.SetAnimationTrigger("Move");
        }

        else
        {
            _character.ArriveDestination();
            _destination = _character.GetTargetPosition();
        }
    }
}
