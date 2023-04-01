public enum SocialClass
{
    Overlord,
    Lord,
    Peasant,
    Length // Keep this at the end
}

[System.Serializable]
public class GameData
{
    public string name = "Player";
    public uint daysPlayed = 0;
    public uint requestsAccepted = 0;
    public uint requestsDeclined = 0;

    public uint treasury = 100;
    public uint landOwned = 10; // in acres
    public uint population = 100;
    public float crimeRate = 1;
    public int[] friendshipScores;

    public void Save(string filename)
    {
        ObjectSaver.Save(filename, this);
    }
}
