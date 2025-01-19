using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public static Scene Instance;
    public string playerName;
    public int highScore;

    private void Awake () {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        } 
        Instance = this;
        LoadHighScore();
        DontDestroyOnLoad(gameObject);
        
      
    }

    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore() {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

    public void LoadHighScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }


}
