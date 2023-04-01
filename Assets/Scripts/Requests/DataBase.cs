using static UnityEngine.Random;

public static class DataBase
{
    private static GameData Data => GameManager.Instance.Data;
    public static Request GetRandomRequest()
    {
        Request[] requests = GetRequests((Request.Category)Range(0, (int)Request.Category.Length));
        if (requests == null) return null;
        return requests[Range(0, requests.Length)];
    }

    public static Request[] GetRequests(Request.Category category)
    {
        switch (category)
        {
            case Request.Category.LandPurchase:
                return LandPurchaseRequests;
            case Request.Category.FiefGiving:
                return FiefGivingRequests;
            case Request.Category.MilitaryAid:
                return MilitaryAidRequests;
            case Request.Category.ResearchInvestments:
                return ClericalRequest;
            case Request.Category.ThiefExecution:
                return ThiefExecutionRequests;
            case Request.Category.FestivalAuthorisation:
                return FestivalAuthorisationRequests;
            case Request.Category.SocialReform:
                return SocialReformRequests;
            case Request.Category.RefugeeAid:
                return RefugeeAidRequests;
            default: return null;
        }
    }

    public static Request[] LandPurchaseRequests = new Request[]
    {
        new Request(
            "Land Purchase",
            "We would like to purchase some land from you.",
            SocialClass.Overlord,
            () => {
                Data.Treasury += Data.LandOwned;
                Data.LandOwned = (uint)(0.9f * Data.LandOwned);
                Data.FriendshipScores[(int)SocialClass.Overlord] += 10;
            },
            () => {
                Data.FriendshipScores[(int)SocialClass.Overlord] -= 10;
            })
    };

    public static Request[] FiefGivingRequests = new Request[]
    {
        new Request(
            "Fief Giving",
            "Please give me some lands!",
            SocialClass.Lord,
            () =>
            {
                Data.LandOwned = (uint)(0.9f * Data.LandOwned);
                Data.FriendshipScores[(int)SocialClass.Lord] += 10;
                Data.FriendshipScores[(int)SocialClass.Peasant] += Range(-5, 6);
            },
            () =>
            {
                Data.FriendshipScores[(int)SocialClass.Lord] -= 10;
                Data.FriendshipScores[(int)SocialClass.Peasant] += Range(0, 11);
            })
    };

    public static Request[] MilitaryAidRequests = new Request[]
    {
        new Request(
            "Please help us!",
            "Our fields are being pillaged by bandits! Please send us some soldiers!",
            SocialClass.Peasant,
            () =>
            {
                Data.CrimeRate--;
                Data.FriendshipScores[(int)SocialClass.Peasant] += 10;
            },
            () =>
            {
                Data.FriendshipScores[(int)SocialClass.Peasant] -= 10;
            })
    };

    public static Request[] ClericalRequest = new Request[]
    {
        new Request(
            "Give you money to God!",
            "GOD WILL SAVE US HE NEED YOUR MONEY TO SAVE YOU FROM HELL! PLEASE GIVE US MONEY!",
            SocialClass.Clergy,
            () =>
            {

            },
            () =>
            {

            })
    };

    public static Request[] ThiefExecutionRequests = new Request[]
    {
        new Request(
            "Placeholder",
            "Thief Execution",
            SocialClass.Peasant,
            () =>
            {

            },
            () =>
            {

            })
    };

    public static Request[] FestivalAuthorisationRequests = new Request[]
    {
        new Request(
            "Placeholder",
            "Festival Authorisation",
            SocialClass.Peasant,
            () =>
            {

            },
            () =>
            {

            })
    };

    public static Request[] SocialReformRequests = new Request[]
    {
        new Request(
            "Placeholder",
            "Social Reform",
            SocialClass.Peasant,
            () =>
            {

            },
            () =>
            {

            })
    };

    public static Request[] RefugeeAidRequests = new Request[]
    {
        new Request(
            "Placeholder",
            "Refugee Aid",
            SocialClass.Peasant,
            () =>
            {

            },
            () =>
            {

            })
    };
}
