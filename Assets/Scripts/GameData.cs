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
    public string Name { get; set; } = "Player";
    public uint DaysPlayed { get; set; } = 0;
    public uint RequestsAccepted { get; set; } = 0;
    public uint RequestsDeclined { get; set; } = 0;

    public uint Treasury { get; set; } = 100;
    public uint LandOwned { get; set; } = 10; // in acres
    public uint Population { get; set; } = 100;
    private uint _crimeRate = 1; // Always between 0 and 100
    public uint CrimeRate { get { return _crimeRate; } set { Min(Max(0, value), 100); } }
    public int[] FriendshipScores { get; set; } = new int[(int)SocialClass.Length]; // init to 0

    public void Save(string filename)
    {
        ObjectSaver.Save(filename, this);
    }
}
