﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    

    public override void Init()
    {
        base.Init();
        _type = eCharacterType.MONSTER;
    }

    protected override void InitState()
    {
        State idleState = new WargIdleState();
        idleState.Init(this);
        _stateList.Add(eState.IDLE, idleState);

        State patrolState = new PatrolState();
        patrolState.Init(this);
        _stateList.Add(eState.PATROL, patrolState);

        State chaseState = new ChaseState();
        chaseState.Init(this);
        _stateList.Add(eState.CHASE, chaseState);

        State attackState = new AttackState();
        attackState.Init(this);
        _stateList.Add(eState.ATTACK, attackState);
    }

    public List<WayPoint> _wayPoints;
    int index = 0;

    public override void ArriveDestination()
    {
        WayPoint wayPoint = _wayPoints[index];
        index = (index + 1) % _wayPoints.Count;
        _targetPosition = wayPoint.GetPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CharacterCtrl"))
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (character.GetCharacterType() == eCharacterType.PLAYER)
            {
                _targetObj = other.gameObject;
                ChangeState(eState.CHASE);
            }
        }
    }

    public override void StopChase()
    {
        ChangeState(eState.PATROL);
    }

    public override bool IsSearchRange(float distance)
    {
        if (distance > GetMaxSearchRange())
        {
            return false;
        }

        return true;
    }
}