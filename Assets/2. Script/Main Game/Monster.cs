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
        base.InitState();

        State idleState = new WargIdleState();
        _stateList[eState.IDLE] = idleState;

        State patrolState = new PatrolState();
        _stateList[eState.PATROL] = patrolState;
    }
}