using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class PnjAskQuest : MonoBehaviour
{
    [SerializeField] GameObject child;
    [SerializeField] GameObject peasant;
    [SerializeField] GameObject vassal;
    [SerializeField] GameObject overLord;

    public Request quest = new();

    public bool _backtrack = false;
    public bool _questStarted = false;
    public bool _questFinished = false;
    private float _speedMove = 1f;
    SocialClass socialClass;

    private void Start()
    {
        quest.Randomize();

    }
    // Update is called once per frame
    void Update()
    {
        socialClass = quest.Importance;
        switch (socialClass)
        {
            case SocialClass.Overlord:
                peasant.SetActive(false);
                vassal.SetActive(false);
                overLord.SetActive(true);
                break;
            case SocialClass.Lord:
                peasant.SetActive(false);
                vassal.SetActive(true);
                overLord.SetActive(false);
                break;
            case SocialClass.Peasant:
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
            }
        }
        if (_questFinished)
        {
            if (!_backtrack)
            {
                child.SetActive(false);
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
                _backtrack= false;
                _questStarted = false;
                _questFinished = false;
                quest.Randomize();
            }
        }


    }



}