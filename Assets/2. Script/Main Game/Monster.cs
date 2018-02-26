using System.Collections;
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
    }

    public List<WayPoint> _wayPoints;
    int index = 0;

    public override void ArriveDestination()
    {
        WayPoint wayPoint = _wayPoints[index];
        index = (index + 1) % _wayPoints.Count;
        _targetPosition = wayPoint.GetPosition();
    }
}