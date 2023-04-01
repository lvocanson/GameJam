using UnityEngine;

public class Apply : MonoBehaviour
{
    [SerializeField] GameObject quest;
    // Start is called before the first frame update

     public void OnClick()
    {
        quest.GetComponent<NPCAskQuest>().request.AcceptConsequences();
        quest.GetComponent<NPCAskQuest>()._questFinished = true;
    }


}
