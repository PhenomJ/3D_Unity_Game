using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    override public void Init()
    {
        base.Init();
        _type = eCharacterType.PLAYER;
    }

    override public void UpdateCharacter() {
        base.UpdateCharacter();
        UpdateInput();
    }
    
    //Move
    void UpdateInput()
    {
        if (InputManager.Instance.IsMouseDown())
        {
            Vector3 mousePosition = InputManager.Instance.GetCursorPosition();

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            LayerMask layerMask = (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("Character"));


            if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    _targetPosition = hit.point;
                    _stateList[_stateType].UpdateInput();
                }

                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Character"))
                {
                    HitArea hitArea = hit.collider.gameObject.GetComponent<HitArea>();
                    Character character = hitArea.GetCharacter();

                    switch(character.GetCharacterType())
                    {
                        case eCharacterType.MONSTER:
                            //적
                            Debug.Log("MONSTER");
                            //_targetPosition = hit.collider.gameObject.transform.position;
                            _targetObj = hit.collider.gameObject;
                            ChangeState(eState.CHASE);
                            break;
                    }
                        
                }
            }
        }

        if (InputManager.Instance.IsAttackButtonDown())
        {
            ChangeState(eState.ATTACK);
        }
    }
}
