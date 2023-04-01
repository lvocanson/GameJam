public struct IntFork
{
    public int MinValue,
               MaxValue;
}

public class Consequence
{
    public IntFork treasury;
    public IntFork landOwned; // in acres
    public IntFork population;
    public IntFork[] friendshipScores;
    public IntFork[] diplomacyScores;

    public Consequence(IntFork treasury, IntFork landOwned, IntFork population, IntFork[] friendshipScores, IntFork[] diplomacyScores)
    {
        this.treasury = treasury;
        this.landOwned = landOwned;
        this.population = population;
        this.friendshipScores = friendshipScores;
        this.diplomacyScores = diplomacyScores;
    }

    public void ApplyConsequence()
    {
        GameData data = GameManager.Instance.Data;
        data.treasury += UnityEngine.Random.Range(treasury.MinValue, treasury.MaxValue);
        data.landOwned += UnityEngine.Random.Range(landOwned.MinValue, landOwned.MaxValue);
        data.population += UnityEngine.Random.Range(population.MinValue, population.MaxValue);
        for (int i = 0; i < (int)SocialClass.Length; i++)
        {
            data.friendshipScores[i] += UnityEngine.Random.Range(friendshipScores[i].MinValue, friendshipScores[i].MaxValue);
        }
        for (int i = 0; i < (int)Country.Length; i++)
        {
            data.diplomacyScores[i] += UnityEngine.Random.Range(diplomacyScores[i].MinValue, diplomacyScores[i].MaxValue);
        }

    }               
}
