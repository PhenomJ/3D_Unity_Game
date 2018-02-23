using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WargIdleState : IdleState {
    
    float deltaIdleTime = 0.0f;

    public override void Update()
    {
        deltaIdleTime += Time.deltaTime;

        // 늑대일 때 일정시간이 지나면 -> 순찰 상태
        if (deltaIdleTime > _character.GetRefreshTime())
        {
            _character.Patrol();
            deltaIdleTime = 0.0f;
        }
    }
}
