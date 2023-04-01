using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameData Data { get; private set; }

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
    }

    private void OnApplicationQuit()
    {
        Data.Save("save1.dat");
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
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
