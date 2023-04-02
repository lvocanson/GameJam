using UnityEngine;
using UnityEngine.UI;

public class ProgressStatBar : MonoBehaviour
{
    [SerializeField] private Image backgroundBar;
    [SerializeField] private Image fillBar;

    private Color BadColor = Color.red;
    private Color AverageColor = Color.yellow;
    private Color GoodColor = Color.green;

    private void Awake()
    {
        backgroundBar.color = AverageColor;
    }

    public void UpdateProgression(int value)
    {
        if (value >= 0)
        {
            fillBar.color = GoodColor;
        }
        else
        {
            fillBar.color = BadColor;
        }
        fillBar.rectTransform.sizeDelta = new Vector2(Mathf.Min(Mathf.Abs(value / 2), 50), fillBar.GetComponent<RectTransform>().sizeDelta.y);
    }
}
