using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    override public void UpdateCharacter() {
        base.UpdateCharacter();
        UpdateInput();
    }
    
    //Move
    void UpdateInput()
    {
        if (InputManager.Instance.IsMouseDown())
        {
            if (InputManager.Instance.GetClickedMouse() == InputManager.eButtonState.LEFT)
            {
                Debug.Log("attack");
                SetAnimationTrigger("Attack");
            }

            else
            {
                Vector3 mousePosition = InputManager.Instance.GetCursorPosition();

                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    _targetPosition = hit.point;
                    _stateList[_stateType].UpdateInput();
                }
            }
        }

    }
}
