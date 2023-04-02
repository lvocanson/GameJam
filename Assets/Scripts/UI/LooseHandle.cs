using UnityEngine;

public class LooseHandle : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI looseTitle;
    [SerializeField] private TMPro.TextMeshProUGUI looseDescription;
    GameData Data { get => GameManager.Instance.Data; }

    private void Awake()
    {
        if (Data == null || Data.IsLosed == false)
        {
            looseTitle.text = "Retry the game!";
            looseDescription.text = string.Empty;
            return;
        }

        if (Data.Treasury < 0)
        {
            looseTitle.text = "Bankrupt!";
            looseDescription.text = "No money left at the end of the day. You're broke man.";
            return;
        }

        if (Data.LandOwned <= 0)
        {
            looseTitle.text = "Homeless!";
            looseDescription.text = "You have no land to live on anymore. Go back to your mom's.";
            return;
        }

        if (Data.Population <= 0)
        {
            looseTitle.text = "Alone!";
            looseDescription.text = "You no longer have any subjects. Skill issue.";
            return;
        }

        for (int i = 0; i < (int)SocialClass.Length; i++)
        {
            if (Data.FriendshipScores[i] <= -100)
            {
                looseTitle.text = "Unpopular!";
                looseDescription.text = "The " + ((SocialClass)i).ToString() + "s just overthrowned you in the night.";
                return;
            }
        }

        looseTitle.text = "Unknown!";
        looseDescription.text = "You have lost the game for an unknown reason (LOL).\n";
    }
}
