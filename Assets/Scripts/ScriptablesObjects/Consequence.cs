using UnityEngine;

[System.Serializable]
public struct Fork
{
    public int min;
    public int max;
}

/// <summary>
/// Request is a ScriptableObject that contains the data for a request.
/// Can be answered by Yes or No.
/// </summary>
[CreateAssetMenu(fileName = "Consequence", menuName = "Scriptable Object/Consequence")]
public class Consequence : ScriptableObject
{
    public Fork TreasuryImpact;
    public Fork LandImpact;
    public Fork[] PopulationImpact = new Fork[(int)SocialClass.Length];
    public Fork[] FriendshipImpact = new Fork[(int)SocialClass.Length];
    public Fork[] DiplomacyImpact = new Fork[(int)Countries.Length];

    public void Apply()
    {
        GameData data = GameManager.Instance.Data;

        data.treasury += Random.Range(TreasuryImpact.min, TreasuryImpact.max);
        data.landOwned += Random.Range(LandImpact.min, LandImpact.max);
        for (int i = 0; i < (int)SocialClass.Length; i++)
        {
            data.population[i] += Random.Range(PopulationImpact[i].min, PopulationImpact[i].max);
            data.friendshipScores[i] += Random.Range(FriendshipImpact[i].min, FriendshipImpact[i].max);
        }
        for (int i = 0; i < (int)Countries.Length; i++)
        {
            data.diplomacyScores[i] += Random.Range(DiplomacyImpact[i].min, DiplomacyImpact[i].max);
        }
    }
}
