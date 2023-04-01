using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RequestNPC : MonoBehaviour
{
    Request quest = new Request();
    // Start is called before the first frame update
    void Start()
    {
        quest.Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = quest.Body;
    }


}
