using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    enum ScreenSettings
    {
        ExclusiveFullScreen,
        Windowed
    }

    private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found!");
        }
    }

    public void QuitGame()
    {
        var gm = gameManager.GetComponent<GameManager>();
        gm.QuitGame();
    }

    public void SaveGame()
    {
        /*var gm = gameManager.GetComponent<GameManager>();
        gm.SaveGame();*/
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
        var gm = gameManager.GetComponent<GameManager>();
        gm.LoadScene(scene);
    }

    public void ChangeVolume(float value)
    {
        var audioManager = gameManager.GetComponent<AudioManager>();
        audioManager.ChangeVolume(value);
    }
}
