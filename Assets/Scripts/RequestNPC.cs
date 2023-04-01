using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RequestNPC : MonoBehaviour
{
    //[SerializeField] Request quest;
    [SerializeField] GameObject quest;
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = quest.GetComponent<PnjAskQuest>().request.Body;

    }
}