using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {

    static InputManager _instance;

    static public InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InputManager();
                _instance.Init();
            }

            return _instance;
        }
    }

    void Init()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (buttonState == eButtonState.UP)
                MouseDown();

            else if (buttonState == eButtonState.DOWN)
                MouseHold();
        }

        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_attackButtonState == eButtonState.UP)
                AttackDown();

            else if (_attackButtonState == eButtonState.DOWN)
                AttackHold();
        }

        if (Input.GetMouseButtonUp(1))
        {
            AttackUp();
        }
    }

    //Mouse Input

    public enum eButtonState
    {
        DOWN,
        HOLD,
        UP,
        LEFT,
    }
    eButtonState buttonState = eButtonState.UP;

    void MouseDown()
    {
        buttonState = eButtonState.DOWN;
    }

    void MouseHold()
    {
        buttonState = eButtonState.HOLD;
    }

    void MouseUp()
    {
        buttonState = eButtonState.UP;
    }

    public bool IsMouseDown()
    {
        return (buttonState == eButtonState.DOWN);
    }

    public bool IsMouseHold()
    {
        return (buttonState == eButtonState.HOLD);
    }

    // Attack

    eButtonState _attackButtonState = eButtonState.UP;

    public bool IsAttackButtonDown()
    {
        return (_attackButtonState == eButtonState.DOWN);
    }

    void AttackDown()
    {
        _attackButtonState = eButtonState.DOWN;
    }

    void AttackHold()
    {
        _attackButtonState = eButtonState.HOLD;
    }

    void AttackUp()
    {
        _attackButtonState = eButtonState.UP;
    }

    public Vector3 GetCursorPosition()
    {
        return Input.mousePosition;
    }
}
