using TMPro;
using UnityEngine;

public class RequestNPC : MonoBehaviour
{
    [SerializeField] GameObject request;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = request.GetComponent<NPCAskQuest>().request.Body;
    }
}