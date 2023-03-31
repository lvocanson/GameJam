using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjAskQuest : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speedMove = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - _speedMove * Time.deltaTime,0,0);
        //2.51
        
    }
}
