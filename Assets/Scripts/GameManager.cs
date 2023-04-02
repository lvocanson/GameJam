using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;
    public GameData Data { get; private set; } = null;
    public AudioManager AudioManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave();
        if (!TryGetComponent(out AudioManager))
            AudioManager = this.AddComponent<AudioManager>();
        AudioManager.PlayBGMenu();
    }

    private void Update()
    {
        GameObject[] buttonsList = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in buttonsList)
        {
            button.GetComponent<Button>().onClick.AddListener(delegate { AudioManager.PlayClick(); }); 
            button.tag = "Untagged";
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        Data.Save("save.dat");
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

    public void NewGame()
    {
        Data = new GameData();
    }

    public void LoadSave()
    {
        Data = ObjectSaver.Load<GameData>("save.dat");
        if (Data == null || Data.IsLosed)
        {
            NewGame();
        }
    }
}
