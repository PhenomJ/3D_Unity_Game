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

        if (Input.GetMouseButtonDown(1))
        {
            MouseDown();
            buttonState = eButtonState.LEFT;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            MouseUp();
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
        return (buttonState == eButtonState.DOWN || buttonState == eButtonState.LEFT);
    }

    public bool IsMouseHold()
    {
        return (buttonState == eButtonState.HOLD);
    }

    public eButtonState GetClickedMouse()
    {
        return buttonState;
    }

    public Vector3 GetCursorPosition()
    {
        return Input.mousePosition;
    }
}
