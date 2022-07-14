using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    private void Awake()
    {
        
    }
    private void Update()
    {
        InputManager.Instance.KeyInput();
    }
    public void InitGame()
    {

    }
}
