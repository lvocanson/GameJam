using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply : MonoBehaviour
{
    [SerializeField] GameObject quest;
    // Start is called before the first frame update

     public void OnClick()
    {
        quest.GetComponent<PnjAskQuest>().quest.AcceptConsequences();
        quest.GetComponent<PnjAskQuest>()._questFinished = true;
    }


}
