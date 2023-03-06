using RedBlueGames.Tools.TextTyper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private FactManager factManager => GameObject.FindGameObjectWithTag("GameController").GetComponent<FactManager>();
    private TextTyper textTyper => GetComponent<TextTyper>();

    private void OnEnable()
    {
        factManager.OnLoadFact += loadFactText;
    }

    private void OnDisable()
    {
        factManager.OnLoadFact -= loadFactText;
    }

    public void loadFactText(Fact _fact)
    {
        textTyper.TypeText("");
        textTyper.TypeText(_fact.FactMessage);
    }
}
