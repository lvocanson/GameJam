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
    public string Name { get; set; } = "Player";
    public int DaysPlayed { get; set; } = 0;
    public int RequestsAccepted { get; set; } = 0;
    public int RequestsDeclined { get; set; } = 0;

    // Statistics
    public int Treasury { get; set; } = 100;
    public float IncomeMultiplier { get; set; } = 1;
    public int LandOwned { get; set; } = 10;
    public int Population { get; set; } = 100;
    private int _crimeRate = 1; // Always between 0 and 100
    public int CrimeRate { get { return _crimeRate; } set { _crimeRate = Min(Max(0, value), 100); } }
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
