using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInputController : Singleton<GlobalInputController>
{
    public PlayerAction playerAction;

    private void Awake()
    {
        playerAction = new PlayerAction();

        playerAction.Enable();
    }
}
