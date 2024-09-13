using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    //Just for testing?
    public TMP_Text wealthDisplay;
    public TMP_Text marketWealthDisplay;


    //these data will persist from the title scene to the main scene to be read (at least by messicontroller)
    public float messiHpLvl;
    public float regenLvl;
    public float regenRatio;
    public float shurikenLvl;
    public float adukeLvl;
    public float diMariaLvl;


    //persistence between sessions data:
    
    //gold and maxlvl
    public int LvlAchieved;
    public int totalWealth;
    
    //how many of each, historic
    public int basicLiberal1Killed;
    public int basicCosplay1Killed;
    public int basicBaldman1Killed;
    public int basicLiberal2Killed;
    
    
    public bool adukeUnlocked;
    //ESTO HAY QUE IMPLEMENTARLO?
    public bool diMariaUnlocked;
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
        optionsUnlocked = false;

        basicLiberal1Killed = 0;
        basicCosplay1Killed = 0;
        basicBaldman1Killed = 0;
        basicLiberal2Killed = 0;

        

        LoadState();

        //why like this? read gbackgroundcontroller
        //new changes: now this setting of wealthdisplay is a function, and is called from
        //titleanimationcontroller. this is because this script (mainmanager) does not awake nor start
        //when it came from another scene (that is: on a restart game for example).
        //until i made this late fix, in the new titlescene after a gameover, the script wouldn't
        //bind to the object (the tmp_text)

        //apparently this problem does not afect the data persistence between scenes.

        //wealthDisplay = GameObject.Find("WealthDisplay").GetComponent<TMP_Text>();
        //wealthDisplay.text = ""+ totalWealth;
    }
    
    [System.Serializable]
    class SaveData
    {
        public int LvlAchieved;
        public int totalWealth;
        public bool adukeUnlocked;
        public bool diMariaUnlocked;
        public bool optionsUnlocked;

        public int basicLiberal1Killed;
        public int basicCosplay1Killed;
        public int basicBaldman1Killed;
        public int basicLiberal2Killed;
    }

    public void IniciateWealthDisplay()
    {
            wealthDisplay = GameObject.Find("WealthDisplay").GetComponent<TMP_Text>();
            wealthDisplay.text = ""+ totalWealth;
    }
    public void IniciateMarketWealthDisplay()
    {
            marketWealthDisplay = GameObject.Find("MarketWealthDisplay(Clone)").GetComponent<TMP_Text>();   
            
            /*GameObject.Find("BuyButtons").GetComponent<BuyButtonsController>().speed;
            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            GameObject.Find("MarketWealthDisplay").GetComponent<TMP_Text>();*/
            marketWealthDisplay.text = ""+ totalWealth;
    }

    public void SaveState()
    {
        SaveData data = new SaveData();
        data.LvlAchieved = LvlAchieved;
        data.totalWealth = totalWealth;

        data.optionsUnlocked = optionsUnlocked;
        data.adukeUnlocked = adukeUnlocked;
        data.diMariaUnlocked = diMariaUnlocked;

        data.basicLiberal1Killed = basicLiberal1Killed;
        data.basicCosplay1Killed = basicCosplay1Killed;
        data.basicBaldman1Killed = basicBaldman1Killed;
        data.basicLiberal2Killed = basicLiberal2Killed;
        

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
            totalWealth = data.totalWealth;

            optionsUnlocked = data.optionsUnlocked;
            adukeUnlocked = data.adukeUnlocked;
            diMariaUnlocked = data.diMariaUnlocked;

            basicLiberal1Killed = data.basicLiberal1Killed;
            basicCosplay1Killed = data.basicCosplay1Killed;
            basicBaldman1Killed = data.basicBaldman1Killed;
            basicLiberal2Killed = data.basicLiberal2Killed;
        }
    }

    public void UnlockAndLock()
    {
        if (!optionsUnlocked)
        {
            optionsUnlocked = true;
        }
        else
        optionsUnlocked = false;
    }
        public void ToggleOptionsLock()
    {
        optionsUnlocked = !optionsUnlocked;
    }
}