using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;



    //public string PlayerName;
    //public string HighScorePlayerName;
    //public int HighScore;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //LoadHighScore();
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); //original code to quit unity.
        #endif
    }

    // old highscrore system
    //[System.Serializable]
    //class SaveData
    //{
    //    public string HighScorePlayerName;
    //    public int HighScore;
    //}

    //public void SaveHighScore()
    //{
    //    SaveData data = new SaveData();
    //    data.HighScorePlayerName = HighScorePlayerName;
    //    data.HighScore = HighScore;

    //    string json = JsonUtility.ToJson(data);

    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //ublic void LoadHighScore()

    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        HighScorePlayerName = data.HighScorePlayerName;
    //        HighScore = data.HighScore;
    //    }
    //}
}
