using TMPro;
using UnityEngine;

public class NameNPC : MonoBehaviour
{
    [SerializeField] GameObject quest;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = quest.GetComponent<NPCAskQuest>().nameNPC;
    }
}