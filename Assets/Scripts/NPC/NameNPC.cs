using TMPro;
using UnityEngine;

public class NameNPC : MonoBehaviour
{
    [SerializeField] GameObject request;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = request.GetComponent<NPCAskQuest>().nameNPC;
    }
}