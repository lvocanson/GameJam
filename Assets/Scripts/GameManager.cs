using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameData Data { get; private set; }
    public AudioManager AudioManager { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Data = ObjectSaver.Load<GameData>("save1.dat");
        if (Data == null)
        {
            Data = new GameData();
        }

        AudioManager = GetComponent<AudioManager>();
        AudioManager.PlayBGMenu();

        GameObject[] buttonsList = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in buttonsList)
        {
            button.GetComponent<Button>().onClick.AddListener(delegate { AudioManager.PlayClick(); });
        }
    }

    private void OnApplicationQuit()
    {
        Data.Save("save1.dat");
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        if (sceneName == "ThroneScene")
        {
            AudioManager.PlayBGGame();
        }
        else
        {
            AudioManager.PlayBGMenu();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSave(string fileName)
    {
        Data = ObjectSaver.Load<GameData>(fileName);
    }
}
