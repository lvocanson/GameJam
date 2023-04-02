using UnityEngine;

public class NPCAskQuest : MonoBehaviour
{
    [SerializeField] GameObject child;
    [SerializeField] GameObject peasant;
    [SerializeField] GameObject vassal;
    [SerializeField] GameObject overLord;
    [SerializeField] GameObject Clergy;

    public Request request;
    public string nameNPC;
    private int turn = 0;

    private bool _backtrack = false;
    public bool _questFinished = false;
    private float _speedMove = 10f;
    SocialClass socialClass;

    private void Start()
    {
        request = DataBase.GetRandomRequest();
        nameNPC = Names.GetRandomName(request.Importance);

    }
    // Update is called once per frame
    void Update()
    {
        socialClass = request.Importance;
        switch (socialClass)
        {
            case SocialClass.Clergy:
                Clergy.SetActive(true);
                peasant.SetActive(false);
                vassal.SetActive(false);
                overLord.SetActive(false);
                break;
            case SocialClass.Overlord:
                Clergy.SetActive(false);
                peasant.SetActive(false);
                vassal.SetActive(false);
                overLord.SetActive(true);
                break;
            case SocialClass.Lord:
                Clergy.SetActive(false);
                peasant.SetActive(false);
                vassal.SetActive(true);
                overLord.SetActive(false);
                break;
            case SocialClass.Peasant:
                Clergy.SetActive(false);
                peasant.SetActive(true);
                vassal.SetActive(false);
                overLord.SetActive(false);
                break;
            case SocialClass.Length:
                break;
            default:
                break;
        }
        if (!_questFinished)
        {
            if (transform.position.x >= 2.51 && _questFinished == false)
            {
                transform.position = new Vector3(transform.position.x - _speedMove * Time.deltaTime, -2.73f, -1);
            }
            else
            {
                child.SetActive(true);
                Clergy.GetComponent<Animator>().speed = 0;
                peasant.GetComponent<Animator>().speed = 0;
                vassal.GetComponent<Animator>().speed = 0;
                overLord.GetComponent<Animator>().speed = 0;
            }
        }
        if (_questFinished)
        {
            if (!_backtrack)
            {
                turn++;
                if (turn == 2)
                {
                    turn = 0;
                    GameManager.Instance.Data.TimeDay += 1;
                    if (GameManager.Instance.Data.TimeDay == 4)
                    {
                        GameManager.Instance.Data.TimeDay = 0;
                    }
                }
                child.SetActive(false);
                Clergy.GetComponent<Animator>().speed = 1;
                peasant.GetComponent<Animator>().speed = 1;
                vassal.GetComponent<Animator>().speed = 1;
                overLord.GetComponent<Animator>().speed = 1;
                _backtrack = true;
                transform.Rotate(0, 180, 0);
            }
            if (transform.position.x <= 11.5)
            {
                transform.position = new Vector3(transform.position.x + _speedMove * Time.deltaTime, -2.73f, -1);
            }
            else
            {
                transform.Rotate(0, 180, 0);
                _backtrack = false;
                _questFinished = false;
                nameNPC = Names.GetRandomName(request.Importance);
                request = DataBase.GetRandomRequest();
            }
        }


    }



}