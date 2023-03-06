using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactMethod", menuName = "ScriptableObjects/FactScriptable", order = 1)]
public class FactMethodScriptable : ScriptableObject
{
    public bool haveWallMat;
    public Material WallMat;
    public Material SkyBox;
    public string objectName;
}
