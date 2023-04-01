using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI crimeRate;
    [SerializeField] TextMeshProUGUI money;
    [SerializeField] TextMeshProUGUI population;
    [SerializeField] GameObject[] friendship;
    [SerializeField] TextMeshProUGUI landOwned;
    [SerializeField] TextMeshProUGUI dayPassed;

    private void Update()
    {
        crimeRate.text = GameManager.Instance.Data.CrimeRate.ToString();
        money.text = GameManager.Instance.Data.Treasury.ToString();
        population.text = GameManager.Instance.Data.Population.ToString();
        landOwned.text = GameManager.Instance.Data.LandOwned.ToString();
        dayPassed.text = GameManager.Instance.Data.DaysPlayed.ToString();

        for (int i = 0; i < friendship.Length; i++)
        {
            friendship[i].GetComponent<ProgressStatBar>().UpdateProgression(GameManager.Instance.Data.FriendshipScores[i]);
        }
    }
}
