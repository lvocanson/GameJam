public enum RequestType
{
    Money,
    Land,
    Alliance,
    War,
    Tribute,
    Length // Keep this at the end
}

public class Request
{
    public RequestType Type { get; private set; } = 0;
    public SocialClass Requester { get; private set; } = 0;
    public string Name { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public System.Action OnAccept { get; private set; } = null;
    public System.Action OnDecline { get; private set; } = null;

    public void Randomize()
    {
        Name = "Request " + UnityEngine.Random.Range(0, 100);
        Body = "Body of " + Name;
        OnAccept = () =>
        {
            UnityEngine.Debug.Log(Name + " accepted.");
        };
        OnDecline = () =>
        {
            UnityEngine.Debug.Log(Name + " declined.");
        };
    }
}
