using System;
using UnityEngine;

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

    public GameData(Vector2Int forkTreasury, Vector2Int forkPopulation, Vector2Int forkFriendship, Vector2Int forkDiplomacy)
    {
        int forkValue = 0;
        name = "Player";
        country = (Country)UnityEngine.Random.Range(0, (int)Country.Length);
        timePlayed = 0f;

        forkValue = UnityEngine.Random.Range(forkTreasury.x, forkTreasury.y);
        treasury = forkValue;
        landOwned = 10;
        forkValue = UnityEngine.Random.Range(forkPopulation.x, forkPopulation.y);
        population = forkValue;
        friendshipScores = new int[(int)SocialClass.Length];
        forkValue = UnityEngine.Random.Range(forkFriendship.x, forkFriendship.y);
        System.Array.Fill(friendshipScores, forkValue);
        diplomacyScores = new int[(int)Country.Length];
        forkValue = UnityEngine.Random.Range(forkDiplomacy.x, forkDiplomacy.y);
        System.Array.Fill(diplomacyScores, 0);
    }
}
