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
            Debug.LogError("GameData is null or game is not lost!");
            return;
        }

        if (Data.Treasury < 0)
        {
            looseTitle.text = "Bankrupt!";
            looseDescription.text = "No money left at the end of the day.\n";
            return;
        }

        if (Data.LandOwned <= 0)
        {
            looseTitle.text = "Homeless!";
            looseDescription.text = "You have no land to live on anymore.\n";
            return;
        }

        if (Data.Population <= 0)
        {
            looseTitle.text = "Alone!";
            looseDescription.text = "You no longer have any subjects.\n";
            return;
        }

        looseTitle.text = "Unknown!";
        looseDescription.text = "You have lost the game for an unknown reason (LOL).\n";
    }
}
