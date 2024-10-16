<h1>Phase Jumper</h1>

![PhaseJumperGP](https://github.com/MicksS1/SideScroll-GameProg/assets/158981991/84f156fe-552a-47bd-acdc-a8668b1820b1)

## 🔴 About This Project
<p align="justify">This is one of my first projects in Unity, designed to help me grasp the fundamentals by building a side-scroller. Through this project, I’ve gained experience with Unity’s 2D physics system, implemented basic player movement, manipulated game objects, worked with tilemaps, and utilized JSON saving data, among other skills.</p>

<br>

## 📋 Project Info

| **Role** | **Team Size** | **Development Time** | **Engine** |
|:-|:-|:-|:-|
| Game Programmer | 1 | 3 weeks | Unity 2022|

<br>

## 👤 Meet the Team
- Michael Ardisa (Lead Programmer, Level Designer & Game Designer)  

<br>

## ♦️About Game
<p align="justify">Phase Jumper is a fast paced side scroller where the main character has the ability to teleport through objects! Try your best to finish the levels as fast as possible with as little deaths as possible.  </p>

<br>

## 🎮 Gameplay
<p align="justify">This game is all about teleportation and parkour! Do your best to avoid traps to finish the level. There are currently 3 levels and I'm planning to add more in the future!  </p>

<br>

## ⚙️ Game Mechanics I Created
### Simple Saving System
<p align="justify">The saving system in PhaseJumper is done by utilizing the JSON file format to store key player data which includes the player's last level, player checkpoint position, death count, and timer. Which is then saved within the game.  </p>

```
// runs everytime the player hits a checkpoint
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

// runs everytime the player dies or presses the "go to last checkpoint" button
public void LoadData()
{
    string PLoadData = File.ReadAllText(Application.dataPath + "/PlayerSaveFile.json");
    PlayerData loadedData = JsonUtility.FromJson<PlayerData>(PLoadData);

    CP.startPos = loadedData.spawnPos;
    PM.deaths = loadedData.deathCount;
    timeData.time = loadedData.timer;

    Debug.Log(PLoadData);
}
```

### Simple Checkpoint System
<p align="justify">The checkpoint system in PhaseJumper integrates with the saving system, triggering a save each time the player reaches a checkpoint. It uses PlayerPrefs to store the player's updated X and Y coordinates, which are later combined into a Vector2 and saved in the JSON file format.</p>

```
private void OnTriggerStay2D(Collider2D coll)
{
    if (coll.gameObject.tag == "Player")
    {
        CPAnim.SetTrigger("GoActive");

        PlayerPrefs.SetFloat("CheckpointX", pos.position.x);
        PlayerPrefs.SetFloat("CheckpointY", pos.position.y);

        SaveManager.SaveData();
    }
}
```

<br>

## 📜 Scripts

|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `GameManager.cs` | Manages the game flow, main menu, pause menu, etc. |
| `AudioManager.cs`  | Responsible for all the audio in the game. |
| `PMove.cs`  | Manages all player movements. |
| `SaveManager.cs`  | Manages the logic behind saving the player's data. |
| `CP_Behaviour.cs`  | Manages the behaviour of checkpoints |
| `etc`  |

<br>

## 🕹️ Controls

| **Key Binding** | **Function** |
|:-|:-|
| A, S, D | Basic movement |
| Space | Jump |
| S-MidAir | Fast-Fall |
| Esc | Pause |
| L-Shift or J | Teleport |

<br>

## 💻 Setup

If you want to try the game out, go to the right of the list of files, click "Releases".
