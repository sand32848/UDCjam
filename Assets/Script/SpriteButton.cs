using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    public Action onButtonClick;

    private void OnMouseUp()
    {
        onButtonClick?.Invoke();
    }
}
