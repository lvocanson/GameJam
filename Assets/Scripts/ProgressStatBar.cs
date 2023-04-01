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

    public void UpdateProgression(int value)
    {
        int score = value;
        if (score > 0)
            progression = score % 50;
        else
            progression = 0;

        if (progression <= 0)
            backgroundImage.color = Color.black;
        else
            backgroundImage.color = progressionColors[progression - 1];

        fillImage.color = progressionColors[progression];
        UpdateBar(score);
    }

    private void UpdateBar(int value)
    {
        int length = value;
        if (length > 50)
            length -= value - (progression * 50);
        if (length <= 0)
        {
            fillBar.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
            if (length < -50)
                length += 50;
        }

        fillBar.GetComponent<RectTransform>().sizeDelta = new Vector2(length, fillBar.GetComponent<RectTransform>().sizeDelta.y);

    }
}
