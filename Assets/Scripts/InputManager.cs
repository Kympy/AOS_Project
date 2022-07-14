using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : SingleTon<InputManager>
{
    public Action KeyAction = null;

    public void KeyInput()
    {
        if(KeyAction == null)
        {
            return;
        }
        if(KeyAction != null)
        {
            KeyAction.Invoke();
        }
    }
}
