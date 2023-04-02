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
        return LandRequests
            .Concat(MilitaryRequests)
            .Concat(ClericalRequest)
            .Concat(PublicOrderRequests)
            .Concat(SocialRequests)
            .ToArray();
    }

    /// <summary>
    /// Get all requests from a category.
    /// </summary>
    public static Request[] GetRequests(Request.Category category)
    {
        switch (category)
        {
            case Request.Category.Land:
                return LandRequests;
            case Request.Category.Military:
                return MilitaryRequests;
            case Request.Category.Clerical:
                return ClericalRequest;
            case Request.Category.PublicOrder:
                return PublicOrderRequests;
            case Request.Category.Social:
                return SocialRequests;
            default: return null;
        }
    }

    public static Request[] LandRequests = new Request[]
    {
        new Request(
            "Land Purchase",
            "We would like to purchase some land from you.",
            SocialClass.Overlord,
            () => {
                Data.Treasury += (int)(0.9f * Data.LandOwned)*20;
                Data.LandOwned = (int)(0.9f * Data.LandOwned);
                Data.FriendshipScores[(int)SocialClass.Overlord] += 10;
            },
            () => {
                Data.FriendshipScores[(int)SocialClass.Overlord] -= 10;
            }),
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
            }),
     new Request(
            "New Market",
            "A merchant has requested permission to build a new market. Allow?",
            SocialClass.Lord,
            () =>
            {
                Data.IncomeMultiplier += 0.01f; // Trade tax
                Data.FriendshipScores[(int)SocialClass.Peasant] += 10;
            },
            () =>
            {
                Data.Population--;
            }),
    new Request(
            "New Town",
            "A merchant has requested permission to build a new town. Allow?",
            SocialClass.Lord,
            () =>
            {
                Data.IncomeMultiplier += 0.05f; // Trade tax
                Data.FriendshipScores[(int)SocialClass.Peasant] += 10;
            },
            () =>
            {
                Data.Population--;
            })
    };

    public static Request[] MilitaryRequests = new Request[]
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
            }),
        new Request(
            "Increase Guard Patrols",
            "Crime rates are rising. Should we increase guard patrols?",
            SocialClass.Lord,
            () =>
            {
                Data.CrimeRate--;
                Data.IncomeMultiplier -= 0.1f; // Cost of patrol
            },
            () =>
            {
                Data.CrimeRate++;
                Data.FriendshipScores[(int)SocialClass.Peasant] -= 5;
            }),
        new Request(
            "Our town is under attack",
            "My town is under attack by a group of criminal! Please send us soldiers.",
            SocialClass.Lord,
            () =>
            {
                Data.CrimeRate--;
                Data.FriendshipScores[(int)SocialClass.Peasant] += 10;
                Data.FriendshipScores[(int)SocialClass.Lord] += 5;
                Data.IncomeMultiplier -= 0.1f; // Cost of patrol
                Data.Treasury -= 30;
            },
            () =>
            {
                Data.CrimeRate++;
                Data.FriendshipScores[(int)SocialClass.Overlord] -= 10;
            }),
        new Request(
            "I found a Redhead Witch Left-handed",
            "I found a Redhead Witch Left-handed, can you send some soldiers? I feel unsafe.",
            SocialClass.Peasant,
            () =>
            {
                Data.CrimeRate--;
                Data.Population--;
                Data.FriendshipScores[(int)SocialClass.Peasant] += 10;
                Data.IncomeMultiplier -= 0.2f; // Cost of patrol
                Data.Treasury += 5;
            },
            () =>
            {
                Data.CrimeRate++;
                Data.FriendshipScores[(int)SocialClass.Peasant] -= 10;
            })
    };

    public static Request[] ClericalRequest = new Request[]
    {
        new Request(
            "God is here!",
            "GOD IS AMONG US! ACCEPT HIM OR GO TO HELL!",
            SocialClass.Clergy,
            () =>
            {
                Data.Treasury /= 2;
                Data.FriendshipScores[(int)SocialClass.Clergy] += 15;
                if (Data.FriendshipScores[(int)SocialClass.Clergy] > 0)
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
            }),
        new Request(
            "Construct a new church",
            "We have requested funds to build a new church. Can you provide support?",
            SocialClass.Clergy,
            () =>
            {
                Data.Treasury -= 25;
                Data.FriendshipScores[(int)SocialClass.Clergy] += 10;
                Data.FriendshipScores[(int)SocialClass.Peasant] += 10;
            },
            () =>
            {
                Data.FriendshipScores[(int)SocialClass.Clergy] -= 10;
            })
    };

    public static Request[] PublicOrderRequests = new Request[]
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
            }),
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
            }),
        new Request(
            "Drink Interdiction",
            "Sir, Can we ban drinking on public roads? Drunk beggars annoy me.",
            SocialClass.Lord,
            () =>
            {
                Data.FriendshipScores[(int)SocialClass.Lord] += 2;
                Data.FriendshipScores[(int)SocialClass.Peasant] = Data.FriendshipScores[(int)SocialClass.Peasant] / 2;
            },
            () =>
            {
                Data.FriendshipScores[(int)SocialClass.Lord] -= 2;
                Data.IncomeMultiplier += 0.1f;
            })
    };

    public static Request[] SocialRequests = new Request[]
    {
        new Request(
            "Increase Taxes",
            "The treasury needs more funds. Should we increase taxes?",
            SocialClass.Overlord,
            () =>
            {
                Data.IncomeMultiplier += 0.5f; // Tax increase
                Data.FriendshipScores[(int)SocialClass.Overlord] += 10;
                Data.FriendshipScores[(int)SocialClass.Lord] += Range(-5, 6);
                Data.FriendshipScores[(int)SocialClass.Peasant] -= Range(0, 11);
            },
            () =>
            {
            }),
        new Request(
            "Tax Break for Farmers",
            "Farmers are struggling due to a harsh winter. Grant them a tax break?",
            SocialClass.Overlord,
            () =>
            {
                Data.IncomeMultiplier -= 0.05f;
                Data.FriendshipScores[(int)SocialClass.Peasant] += Range(5, 16);
                Data.CrimeRate--;
            },
            () =>
            {
            }),
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
                Data.CrimeRate++;
            })
    };

    /* -- NEW REQUEST TEMPLATE --,
     new Request(
            "NAME",
            "SUMMARY & CLOSED QUESTION",
            ASKER,
            () =>
            {
                // On Accept...
            },
            () =>
            {
                // On Decline...
            })
    */
}
