using TMPro;
using UnityEngine;

public class RequestNPC : MonoBehaviour
{
    [SerializeField] GameObject quest;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = quest.GetComponent<NPCAskQuest>().request.Body;
    }
}