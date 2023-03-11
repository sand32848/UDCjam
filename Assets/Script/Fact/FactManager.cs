using Cinemachine;
using RedBlueGames.Tools.TextTyper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactManager : MonoBehaviour
{
    private Fact currfact;
    [SerializeField] private List<Fact> factList = new List<Fact>();
    private int currentFactIndex = -1;

    public Action<Fact> OnLoadFact;

    private void OnEnable()
    {
        ComputerInterface.onQuestionButtonClick += CallNextFact;
    }

    private void OnDisable()
    {
        ComputerInterface.onQuestionButtonClick -= CallNextFact;
    }

    public void CallNextFact()
    {
        currentFactIndex++;
        currfact = factList[currentFactIndex];

        OnLoadFact?.Invoke(currfact);
    }

    //IEnumerator waitFact()
    //{
    //    yield return new WaitForSeconds();
    //}
}
