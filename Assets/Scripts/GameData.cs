public enum SocialClass
{
    King,
    GreatLord,
    Lord,
    Knight,
    Squire,
    Peasant,
    Slave,
    Length // Keep this at the end
}

public enum Countries
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
    public float timePlayed;

    public int treasury; 
    public int landOwned; // in acres
    public int[] friendshipScores = new int[(int)SocialClass.Length];
    public int[] diplomacyScores = new int[(int)Countries.Length];

    public GameData()
    {
        name = "Player";
        timePlayed = 0f;

        treasury = 0;
        landOwned = 0;
        System.Array.Fill(friendshipScores, 0);
        System.Array.Fill(diplomacyScores, 0);
    }
}
