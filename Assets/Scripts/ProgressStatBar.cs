using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressStatBar : MonoBehaviour
{
    [SerializeField] private GameObject backgroundBar;
    [SerializeField] private GameObject fillBar;

    private Image backgroundImage;
    private Image fillImage;

    private Color[] progressionColors = new Color[7];
    private int progression;

    void Start()
    {
        progressionColors[0] = Color.red;
        progressionColors[1] = Color.yellow;
        progressionColors[2] = Color.green;
        progressionColors[3] = Color.blue;
        progressionColors[4] = Color.magenta;
        progressionColors[5] = Color.cyan;
        progressionColors[6] = Color.white;

        progression = 0;

        backgroundImage = backgroundBar.GetComponent<Image>();
        fillImage = fillBar.GetComponent<Image>();
    }

    public void UpdateProgression(int friendship)
    {
        progression = friendship % 50;
        if (progression == 0)
            backgroundImage.color = Color.black;
        else 
            backgroundImage.color = progressionColors[progression-1];

        fillImage.color = progressionColors[progression];
    }
}
