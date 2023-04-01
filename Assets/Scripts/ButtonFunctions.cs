using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    enum ScreenSettings
    {
        ExclusiveFullScreen,
        Windowed
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void BackButton(GameObject canceled)
    {
        canceled.SetActive(false);
    }

    public void ActivateOptionPanel()
    {
        var optionPanel = GameObject.FindGameObjectWithTag("Option");
        optionPanel.SetActive(true);
    }

    public void ChangeScreenSettings(int value)
    {
        switch (value)
        {
            case (int)ScreenSettings.ExclusiveFullScreen:
                Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.ExclusiveFullScreen,
                    Screen.currentResolution.refreshRate);
                break;
            case (int)ScreenSettings.Windowed:
                Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.Windowed,
                    Screen.currentResolution.refreshRate);
                break;
        }
    }

    public void LoadScene(string scene)
    {
        GameManager.Instance.LoadScene(scene);
    }

    public void ChangeVolume(float value)
    {
        GameManager.Instance.GetComponent<AudioManager>().ChangeVolume(value);
    }
}
