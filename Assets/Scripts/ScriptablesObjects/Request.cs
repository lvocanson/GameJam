using UnityEngine;

/// <summary>
/// Request is a ScriptableObject that contains the data for a request.
/// Can be answered by Yes or No.
/// </summary>
[CreateAssetMenu(fileName = "Request", menuName = "Scriptable Object/Request")]
public class Request : ScriptableObject
{
    public string Name;
    public string Description;
    public Consequence YesConsequence;
    public Consequence NoConsequence;

    public void Yes()
    {
        YesConsequence.Apply();
    }

    public void No()
    {
        NoConsequence.Apply();
    }
}
