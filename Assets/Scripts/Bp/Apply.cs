using UnityEngine;

public class Apply : MonoBehaviour
{
    [SerializeField] GameObject quest;

     public void OnClick()
    {
        quest.GetComponent<NPCAskQuest>().request.AcceptConsequences();
        quest.GetComponent<NPCAskQuest>()._questFinished = true;
    }
}
