using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
using static UnityEngine.Mathf;

public enum SocialClass
{
    Clergy,
    Overlord,
    Lord,
    Peasant,
    Length // Keep this at the end
}

[System.Serializable]
public class GameData
{
    // Consts
    public const int NumberOfRequestsDaily = 8;

    // Game Data
    public bool IsLosed { get; set; } = false;
    public string Name { get; set; } = "Player";
    public int DaysPlayed { get; private set; } = 1;
    public int RequestsAccepted { get; set; } = 0;
    public int RequestsDeclined { get; set; } = 0;
    private int _timeDay = 0;
    public int TimeDay
    {
        get { return _timeDay; }
        set
        {
            _timeDay = value;
            if (value >= 4) // New day
            {
                _timeDay = 0;
                DaysPlayed++;
                Treasury += DailyIncome;
                Population -= Random.Range(0, Population * CrimeRate / 100);
                if (Treasury < 0)
                {
                    IsLosed = true;
                }
                for (int i = 0; i < (int)SocialClass.Length; i++)
                {
                    if (FriendshipScores[i] <= -100)
                    {
                        IsLosed = true;
                    }
                }
            }
        }
    }

    // Statistics
    public int Treasury { get; set; } = 100;
    public float IncomeMultiplier { get; set; } = 1;
    private int _landOwned = 10;
    public int LandOwned
    {
        get { return _landOwned; }
        set
        {
            _landOwned = value;
            Population = Population; // Update population
            if (value <= 0)
                IsLosed = true;
        }
    }
    private int _population = 100;
    public int Population
    {
        get { return _population; }
        set
        {
            _population = Min(value, LandOwned * 25);
            if (value <= 0)
                IsLosed = true;
        }
    }
    private int _crimeRate = 1; // Always between 0 and 100
    public int CrimeRate { get { return _crimeRate; } set { _crimeRate = Clamp(value, 0, 100); } }
    public int[] FriendshipScores { get; set; } = new int[(int)SocialClass.Length]; // init to 0

    // Auto properties
    public int DailyIncome
    {
        get
        {
            return (int)(Population * IncomeMultiplier - LandOwned) / 10;
        }
    }

    public void Save(string filename)
    {
        ObjectSaver.Save(filename, this);
    }
}
