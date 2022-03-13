using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GlobalData : MonoBehaviour
{
    [HideInInspector]
    public static GlobalData Instance;

    public DataToSave data = new DataToSave();

    [System.Serializable]
    public class DataToSave
    {
        public int HighScore;
        public string HighName;
        public string Name;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else Destroy(gameObject); //already one instance so destroy this one
    }

#if UNITY_EDITOR
    public void Exit()
    {
        SaveData();
        EditorApplication.ExitPlaymode();
    }
#else
    public void Exit()
    {
        SaveData();
        Application.Quit;
    }
#endif

    public void SaveData()
    {
        File.WriteAllText(Application.persistentDataPath + "/config.json", JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/config.json";
        if (File.Exists(path))
            data = JsonUtility.FromJson<DataToSave>(File.ReadAllText(path));
    }
}

