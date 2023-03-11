using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentRenderer : MonoBehaviour
{
    private FactManager factManager  => GetComponent<FactManager>();
    [SerializeField] private List<Renderer> wallRenderers = new List<Renderer>();
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
        wallRenderers.ForEach(x => x.material = baseWallMat);
        if (_fact.Method.SkyBox) RenderSettings.skybox = baseSkybox;
        if (tempObj) tempObj.SetActive(false);
        //

        tempObj = _fact.FactObject;
        tempObj.SetActive(true);

        if (_fact.Method.SkyBox) RenderSettings.skybox = _fact.Method.SkyBox;
        if (_fact.Method.WallMat) wallRenderers.ForEach(x => x.material = _fact.Method.WallMat); 
    
    }
}

