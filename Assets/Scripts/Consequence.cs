public struct IntFork
{
    public IntFork(int min, int max)
    {
        Min = min;
        Max = max;
    }
    public int Min,
               Max;
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
        data.treasury += UnityEngine.Random.Range(treasury.Min, treasury.Max);
        data.landOwned += UnityEngine.Random.Range(landOwned.Min, landOwned.Max);
        data.population += UnityEngine.Random.Range(population.Min, population.Max);
        for (int i = 0; i < (int)SocialClass.Length; i++)
        {
            data.friendshipScores[i] += UnityEngine.Random.Range(friendshipScores[i].Min, friendshipScores[i].Max);
        }
        for (int i = 0; i < (int)Country.Length; i++)
        {
            data.diplomacyScores[i] += UnityEngine.Random.Range(diplomacyScores[i].Min, diplomacyScores[i].Max);
        }

    }               
}
