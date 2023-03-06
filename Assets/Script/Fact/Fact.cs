using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fact : MonoBehaviour
{
    [field: SerializeField] public string FactMessage { get; private set; }
    [field: SerializeField] public FactMethodScriptable Method { get; private set; }
    [field: SerializeField] public float SceneChangeDelay { get; private set; }

}
