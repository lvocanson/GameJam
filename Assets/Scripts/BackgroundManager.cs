using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private void Update()
    {

        transform.GetChild(GameManager.Instance.Data.TimeDay).gameObject.SetActive(true);
        
       
    }


}
