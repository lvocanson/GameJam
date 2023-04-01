using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuse : MonoBehaviour
{
    [SerializeField] GameObject quest;

    public void OnClick()
    {
        quest.GetComponent<PnjAskQuest>().request.AcceptConsequences();
        quest.GetComponent<PnjAskQuest>()._questFinished = true;
    }
}
