public class Request
{
    public string Name { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public SocialClass Importance { get; private set; } = 0;
    public event System.Action OnAccept;
    public event System.Action OnDecline;

    public void AcceptConsequences()
    {
        OnAccept?.Invoke();
    }

    public void DeclineConsequences()
    {
        OnDecline?.Invoke();
    }

    public void Randomize()
    {
        Importance = (SocialClass)UnityEngine.Random.Range(0, (int)SocialClass.Length);
        Name = Names.GetRandomName(Importance) + "'s request";
        Body = "This is a request from " + Names.GetRandomName(Importance);
    }
}
