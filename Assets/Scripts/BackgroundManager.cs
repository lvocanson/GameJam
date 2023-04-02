using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] GameObject matin;
    [SerializeField] GameObject jour;
    [SerializeField] GameObject soire;
    [SerializeField] GameObject nuit;
    private void Update()
    {
        switch (GameManager.Instance.Data.TimeDay)
        {
            case 0:
                matin.SetActive(true);
                jour.SetActive(false);
                soire.SetActive(false);  
                nuit.SetActive(false);
                break;
            case 1:
                matin.SetActive(false);
                jour.SetActive(true);
                soire.SetActive(false);
                nuit.SetActive(false);
                break;
            case 2:
                matin.SetActive(false);
                jour.SetActive(false);
                soire.SetActive(true);
                nuit.SetActive(false);
                break;
            case 3:
                matin.SetActive(false);
                jour.SetActive(false);
                soire.SetActive(false);
                nuit.SetActive(true);
                break;
            default:
                break;
        }
    }
}
