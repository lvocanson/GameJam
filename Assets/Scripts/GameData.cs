public enum SocialClass
{
    Overlord,
    Lord,
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

    public GameData(IntFork forkTreasury, IntFork forkPopulation, IntFork forkFriendship, IntFork forkDiplomacy)
    {
        name = "Player";
        country = (Country)UnityEngine.Random.Range(0, (int)Country.Length);
        timePlayed = 0f;

        treasury = UnityEngine.Random.Range(forkTreasury.Min, forkTreasury.Max);
        landOwned = 10;
        population = UnityEngine.Random.Range(forkPopulation.Min, forkPopulation.Max);
        friendshipScores = new int[(int)SocialClass.Length];
        System.Array.Fill(friendshipScores, UnityEngine.Random.Range(forkFriendship.Min, forkFriendship.Max));
        diplomacyScores = new int[(int)Country.Length];
        System.Array.Fill(diplomacyScores, UnityEngine.Random.Range(forkDiplomacy.Min, forkDiplomacy.Max));
    }
}
