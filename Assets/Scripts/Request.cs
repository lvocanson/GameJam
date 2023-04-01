public enum RequestType
{
    Financing,
    FiefDonation,
    Alliance,
    MilitaryIntervention,
    Tribute,
    Length // Keep this at the end
}

public class Request
{
    public RequestType Type { get; private set; } = 0;
    public SocialClass Requester { get; private set; } = 0;
    public string Name { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public Consequence Accept { get; private set; } = null;
    public Consequence Decline { get; private set; } = null;

    public Request()
    {
        Randomize();
    }

    public void AcceptConsequences()
    {
        Accept?.ApplyConsequence();
    }

    public void DeclineConsequences()
    {
        Decline?.ApplyConsequence();
    }

    public void Randomize()
    {
        Type = (RequestType)UnityEngine.Random.Range(0, (int)RequestType.Length);
        Requester = (SocialClass)UnityEngine.Random.Range(0, (int)SocialClass.Length);

        switch (Type)
        {
            case RequestType.Financing:
                GenerateFinancingRequest();
                break;
            case RequestType.FiefDonation:
                GenerateFiefDonationRequest();
                break;
            case RequestType.Alliance:
                GenerateAllianceRequest();
                break;
            case RequestType.MilitaryIntervention:
                GenerateMilitaryInterventionRequest();
                break;
            case RequestType.Tribute:
                GenerateTributeRequest();
                break;
            default: throw new System.Exception("Invalid RequestType");
        }
    }

    private void GenerateFinancingRequest()
    {
        Name = "Financing Request";
        Body = "We need money to pay our soldiers. Please give us some.";
    }

    private void GenerateFiefDonationRequest()
    {
        Name = "Fief Donation Request";
        Body = "We need a fief to house our soldiers. Please give us one.";
    }

    private void GenerateAllianceRequest()
    {
        Name = "Alliance Request";
        Body = "We need an alliance to fight our enemies. Please give us one.";
    }

    private void GenerateMilitaryInterventionRequest()
    {
        Name = "Military Intervention Request";
        Body = "We need military intervention to fight our enemies. Please give us one.";
    }

    private void GenerateTributeRequest()
    {
        Name = "Tribute Request";
        Body = "We need tribute to pay our soldiers. Please give us some.";
    }
}
