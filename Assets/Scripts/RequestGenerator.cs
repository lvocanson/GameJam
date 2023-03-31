public class RequestGenerator
{
    static public Request GenerateRequest()
    {
        Request request = new Request();
        request.Name = "Request " + UnityEngine.Random.Range(0, 100);
        request.Body = "Body " + UnityEngine.Random.Range(0, 100);
        request.OnAccept = () => { 
            
        };
        return request;
    }
}
