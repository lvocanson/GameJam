using System.Linq;
using static UnityEngine.Random;

public static class DataBase
{
    private static GameData Data => GameManager.Instance.Data;

    /// <summary>
    /// Get a random request from all categories.
    /// </summary>
    public static Request GetRandomRequest()
    {
        Request[] requests = GetRequests();
        if (requests == null) return null;
        return requests[Range(0, requests.Length)];
    }

    /// <summary>
    /// Get a random request from a category.
    /// </summary>
    public static Request GetRandomRequest(Request.Category category)
    {
        Request[] requests = GetRequests(category);
        if (requests == null) return null;
        return requests[Range(0, requests.Length)];
    }

    /// <summary>
    /// Get all requests from all categories.
    /// </summary>
    public static Request[] GetRequests()
    {
        return LandPurchaseRequests
            .Concat(FiefGivingRequests)
            .Concat(MilitaryAidRequests)
            .Concat(ClericalRequest)
            .Concat(ThiefExecutionRequests)
            .Concat(FestivalAuthorisationRequests)
            .Concat(SocialReformRequests)
            .Concat(RefugeeAidRequests)
            .ToArray();
    }

    /// <summary>
    /// Get all requests from a category.
    /// </summary>
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
                Data.LandOwned = (int)(0.9f * Data.LandOwned);
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
                Data.LandOwned = (int)(0.9f * Data.LandOwned);
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
            "Give your money to God!",
            "GOD WILL SAVE US HE NEED YOUR MONEY TO SAVE YOU FROM HELL! PLEASE GIVE US MONEY!",
            SocialClass.Clergy,
            () =>
            {
                Data.Treasury /= 2;
                Data.FriendshipScores[(int)SocialClass.Clergy] += 15;
                if (Data.FriendshipScores[(int)SocialClass.Clergy] < 0)
                {
                    Data.FriendshipScores[(int)SocialClass.Overlord] += Range(10, 21);
                    Data.FriendshipScores[(int)SocialClass.Lord] += Range(5, 16);
                    Data.FriendshipScores[(int)SocialClass.Peasant] += Range(0, 11);
                }
            },
            () =>
            {
                Data.FriendshipScores[(int)SocialClass.Clergy] -= 25;
                if (Data.FriendshipScores[(int)SocialClass.Clergy] < 0)
                {
                    Data.FriendshipScores[(int)SocialClass.Overlord] -= Range(10, 21);
                    Data.FriendshipScores[(int)SocialClass.Lord] -= Range(5, 16);
                    Data.FriendshipScores[(int)SocialClass.Peasant] -= Range(0, 11);
                }
            })
    };

    public static Request[] ThiefExecutionRequests = new Request[]
    {
        new Request(
            "Final decision",
            "A thief has stolen apples. Have we to execute him?",
            SocialClass.Lord,
            () =>
            {
                Data.CrimeRate /= 2;
                Data.Population--;
                Data.FriendshipScores[(int)SocialClass.Lord] += 5;
                Data.FriendshipScores[(int)SocialClass.Peasant] += Range(-10, 11);
            },
            () =>
            {
                Data.CrimeRate += 3;
                Data.FriendshipScores[(int)SocialClass.Lord] -= 5;
                Data.FriendshipScores[(int)SocialClass.Peasant] += Range(-5, 6);
            })
    };

    public static Request[] FestivalAuthorisationRequests = new Request[]
    {
        new Request(
            "Carnival Authorisation",
            "Sir, Can we organaise a carnival?",
            SocialClass.Peasant,
            () =>
            {
                Data.Treasury -= Data.Population / 3;
                Data.Population += Range(5, 101);
            },
            () =>
            {
                Data.Population -= Range(0, Data.Population / 10);
            })
    };

    public static Request[] SocialReformRequests = new Request[]
    {
        new Request(
            "Increase Taxes",
            "The treasury needs more funds. Should we increase taxes?",
            SocialClass.Overlord,
            () =>
            {
                Data.TaxesMultiplier += 0.1f;
                Data.FriendshipScores[(int)SocialClass.Overlord] += 10;
                Data.FriendshipScores[(int)SocialClass.Lord] += Range(-5, 6);
                Data.FriendshipScores[(int)SocialClass.Peasant] -= Range(0, 11);
            },
            () =>
            {
            })
    };

    public static Request[] RefugeeAidRequests = new Request[]
    {
        new Request(
            "Help Refugees",
            "Will you provide aid to the refugees who have fled from the war-torn neighboring kingdom?",
            SocialClass.Lord,
            () =>
            {
                int num = Range(10, 100);
                Data.Population += num;
                Data.Treasury -= num;
            },
            () =>
            {
                Data.CrimeRate += 3;
            })
    };
}
