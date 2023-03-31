using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PnjAskQuest : MonoBehaviour
{
    public bool _questStarted = false;
    private float _speedMove = 1f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 2.51)
        {
            transform.position = new Vector3(transform.position.x - _speedMove * Time.deltaTime, 0, 0);

        }
        else
        {
            _questStarted= true;
        }


    }



}