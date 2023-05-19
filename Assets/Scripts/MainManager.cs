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

    //these data will persist from the title scene to the main scene to be read (at least by messicontroller)
    public float messiHpLvl;
    public float regenLvl;
    public float regenRatio;
    public float shurikenLvl;
    public float adukeLvl;


    //persistence between sessions data:
    public int LvlAchieved;
    public bool adukeUnlocked;
    public bool optionsUnlocked;



    private void Awake()
    {
        Time.timeScale = 1;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        shurikenLvl = 1;

        // optionsunlocked by default (remember to uncomment this on the savedata class and save and load data
        // functions)
        optionsUnlocked = true;

    
        
       //LoadHighScore();
       LoadState();
    }
    
    [System.Serializable]
    class SaveData
    {
        public int LvlAchieved;
        public bool adukeUnlocked;
        //public bool optionsUnlocked;
    }

    public void SaveState()
    {
        SaveData data = new SaveData();
        data.LvlAchieved = LvlAchieved;
        //data.optionsUnlocked = optionsUnlocked;
        data.adukeUnlocked = adukeUnlocked;
        

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadState()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            LvlAchieved = data.LvlAchieved;
            //optionsUnlocked = data.optionsUnlocked;
            adukeUnlocked = data.adukeUnlocked;
        }
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
