using UnityEditor;
using UnityEngine;

public class GameDataEditor : EditorWindow
{
    GameData data = null;
    string filename = "save1.dat";
    bool showRuntimeGameData = false;
    bool showFriendships = true;

    [MenuItem("Editor/Game Data Editor")]
    public static void ShowWindow()
    {
        GetWindow<GameDataEditor>("Game Data Editor");
    }

    private void Update()
    {
        if (showRuntimeGameData)
            Repaint();
    }

    private void OnGUI()
    {
        if (data == null)
        {
            ShowLoader();
        }
        else
        {
            ShowData();
        }
    }

    private void ShowLoader()
    {
        EditorGUILayout.LabelField("Load Game Data", EditorStyles.boldLabel);

        EditorGUILayout.TextField("Filename", filename);
        if (GUILayout.Button("Load Game Data from a file"))
        {
            data = ObjectSaver.Load<GameData>(filename);
        }

        if (GameManager.Instance != null)
        {
            if (GUILayout.Button("Load Game Data from runtime"))
            {
                data = GameManager.Instance.Data;
                showRuntimeGameData = true;
            }
        }
    }

    private void ShowData()
    {
        if (GUILayout.Button("Unload"))
        {
            data = null;
            return;
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Game Data", EditorStyles.boldLabel);
        EditorGUILayout.TextField("Name", data.Name);
        EditorGUILayout.IntField("Days Played", data.DaysPlayed);
        EditorGUILayout.IntField("Requests Accepted", data.RequestsAccepted);
        EditorGUILayout.IntField("Requests Declined", data.RequestsDeclined);
        EditorGUILayout.IntField("Time Day", data.TimeDay);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Statistics", EditorStyles.boldLabel);
        EditorGUILayout.IntField("Treasury", data.Treasury);
        EditorGUILayout.FloatField("Income Multiplier", data.IncomeMultiplier);
        EditorGUILayout.IntField("Land Owned", data.LandOwned);
        EditorGUILayout.IntField("Population", data.Population);
        EditorGUILayout.IntSlider("Crime Rate", data.CrimeRate, 0, 100);

        if (EditorGUILayout.Foldout(showFriendships, "Friendship Scores"))
        {
            for (int i = 0; i < data.FriendshipScores.Length; i++)
            {
                EditorGUILayout.IntField(((SocialClass)i).ToString(), data.FriendshipScores[i]);
            }
        }

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Auto Properties", EditorStyles.boldLabel);
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.IntField("Daily Income", data.DailyIncome);
        EditorGUI.EndDisabledGroup();
    }
}
