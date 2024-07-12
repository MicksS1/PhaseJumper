using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public Scene activeScene;
    private string level;
    public CP_Behaviour CP;
    public PMove PM;
    public Timer timeData;
    public GameManager gameManager;
    public int loadSave;

    private void Awake()
    {
        activeScene = SceneManager.GetActiveScene();
        level = activeScene.name;

        CP = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CP_Behaviour>();
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PMove>();
        timeData = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();

        loadSave = PlayerPrefs.GetInt("loadSave");
        PlayerPrefs.SetInt("FirstRun", 1);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    // auto-save from last checkpoint

    public class PlayerData
    {
        public string level;
        public Vector2 spawnPos;
        public int deathCount;
        public float timer;
    }

    public void firstLoad()
    {
        PlayerData firstData = new PlayerData();
        firstData.level = null;
        firstData.spawnPos = new Vector2(0, 0);
        firstData.deathCount = 0;
        firstData.timer = 0f;

        string FData = JsonUtility.ToJson(firstData);
        File.WriteAllText(Application.dataPath + "/PlayerSaveFile.json", FData);

        Debug.Log(FData);

        PlayerPrefs.SetInt("FirstRun", 0);
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.level = level;
        data.spawnPos = CP.newPos;
        data.deathCount = PM.deaths;
        data.timer = timeData.time;

        string PData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/PlayerSaveFile.json", PData);
        
        Debug.Log(PData);
    }

    public void LoadData()
    {
        string PLoadData = File.ReadAllText(Application.dataPath + "/PlayerSaveFile.json");
        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(PLoadData);

        CP.startPos = loadedData.spawnPos;
        PM.deaths = loadedData.deathCount;
        timeData.time = loadedData.timer;

        Debug.Log(PLoadData);
    }

    //public void save()
    //{
    //    PlayerData coba = new PlayerData();
    //    coba.level = level;

    //    string file = JsonUtility.ToJson(coba);
    //    File.WriteAllText("/saveFile", file);
    //}

    //public void load()
    //{
    //    string lod = File.ReadAllText("/saveFile");
    //    PlayerData data = JsonUtility.FromJson<PlayerData>(lod);

    //    data.level = level;
    //}
}
