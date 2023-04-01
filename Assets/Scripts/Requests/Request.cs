
public class Request
{
    public enum Category
    {
        LandPurchase,
        FiefGiving,
        MilitaryAid,
        ResearchInvestments,
        ThiefExecution,
        FestivalAuthorisation,
        SocialReform,
        RefugeeAid,
        Length // Keep this last
    }

    public string Name { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public SocialClass Importance { get; private set; } = SocialClass.Length;
    public event System.Action OnAccept;
    public event System.Action OnDecline;

    public Request(string name, string body, SocialClass importance, System.Action onAccept, System.Action onDecline)
    {
        Name = name;
        Body = body;
        Importance = importance;
        OnAccept += onAccept;
        OnDecline += onDecline;
    }

    public void AcceptConsequences()
    {
        OnAccept?.Invoke();
        GameManager.Instance.Data.RequestsAccepted++;
    }

    public void DeclineConsequences()
    {
        OnDecline?.Invoke();
        GameManager.Instance.Data.RequestsDeclined++;
    }
}
