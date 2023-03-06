using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentRenderer : MonoBehaviour
{
    private FactManager factManager  => GetComponent<FactManager>();
    [SerializeField] private Renderer wallRenderer;
    [SerializeField] private Material baseSkyboxMat;
    [SerializeField] private Material baseWallMat;
    [SerializeField] private Material transparentWallMat;
    Material baseSkybox;
    GameObject tempObj;

    private void OnEnable()
    {
        factManager.OnLoadFact += loadFactEnvironment;
    }

    private void OnDisable()
    {
        factManager.OnLoadFact -= loadFactEnvironment;
    }

    private void loadFactEnvironment(Fact _fact)
    {
        //clear previous environment
        wallRenderer.material = baseWallMat;
        if (_fact.Method.SkyBox) RenderSettings.skybox = baseSkybox;
        if (tempObj) tempObj.SetActive(false);
        //

        tempObj = _fact.FactObject;
        tempObj.SetActive(true);

        if (_fact.Method.SkyBox) RenderSettings.skybox = _fact.Method.SkyBox;
        if (_fact.Method.WallMat) wallRenderer.material = _fact.Method.WallMat;
    
    }
}

