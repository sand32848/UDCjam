using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private PlayerAction playerAction;
    private InputAction inputAction;
    // Start is called before the first frame update
    void Start()
    {
        playerAction = new PlayerAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
