using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using static SaveManager;
using static UnityEditor.PlayerSettings;
//using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public Scene activeScene;
    public int loadSave;
    private string levelData;
    private string levelName;
    private string sceneName;

    private void Awake()
    {
        activeScene = SceneManager.GetActiveScene();

        levelData = File.ReadAllText(Application.dataPath + "/PlayerSaveFile.json");
        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(levelData);

        levelName = loadedData.level;
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeSelf == false && activeScene.name != "MenuScene" && Input.GetKeyDown(KeyCode.Escape))
            Pause();
        
        else if (menu.activeSelf && activeScene.name != "MenuScene" && Input.GetKeyDown(KeyCode.Escape))
            Resume();
    }

    public void ChangeScene(string sceneName)
    {
        PlayerPrefs.SetInt("loadSave", 0);
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeToSavedScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene()
    {
        PlayerPrefs.SetInt("loadSave", 1);
        loadSave = PlayerPrefs.GetInt("loadSave");
        Debug.Log(loadSave);

        if (levelName == "TutorialScene")
            ChangeToSavedScene("TutorialScene");

        else if (levelName == "Level1")
            ChangeToSavedScene("Level1");

        else if (levelName == "Level2")
            ChangeToSavedScene("Level2");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(activeScene.name);

        //menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
