public class Request
{
    public string Name { get; private set; }
    public string Body { get; private set; }
    public System.Action OnAccept { get; private set; }
    public System.Action OnDecline { get; private set; }

    public Request()
    {
        Name = null;
        Body = null;
        OnAccept = null;
        OnDecline = null;
    }

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
