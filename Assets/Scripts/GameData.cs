public enum SocialClass
{
    Overlord,
    Vassal,
    Peasant,
    Length // Keep this at the end
}

public enum Country
{
    England,
    France,
    Spain,
    Length // Keep this at the end
}

[System.Serializable]
public class GameData
{
    public string name;
    public Country country;
    public float timePlayed;

    public int treasury; 
    public int landOwned; // in acres
    public int population;
    public int[] friendshipScores;
    public int[] diplomacyScores;

    public GameData()
    {
        name = "Player";
        country = (Country)UnityEngine.Random.Range(0, (int)Country.Length);
        timePlayed = 0f;

        treasury = 0;
        landOwned = 0;
        population = 0;
        friendshipScores = new int[(int)SocialClass.Length];
        System.Array.Fill(friendshipScores, 0);
        diplomacyScores = new int[(int)Country.Length];
        System.Array.Fill(diplomacyScores, 0);
    }
}
