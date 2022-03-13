using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class Menu : MonoBehaviour
{
    public GameObject nameField;
    public GameObject highScore;
    private void Start()
    {
        ShowName();
        ShowHighScore();
    }


    public void StartGame() { SceneManager.LoadScene(1); }
    public void ShowName() { nameField.GetComponent<InputField>().text = GlobalData.Instance.data.Name; }
    public void SaveName() {
        GlobalData.Instance.data.Name = nameField.GetComponent<InputField>().text;
        GlobalData.Instance.SaveData();
    }
    public void ShowHighScore()
    {
        highScore.GetComponent<Text>().text = "High Score: " + GlobalData.Instance.data.HighName + " - " + GlobalData.Instance.data.HighScore;
    }
    public void Quit() { GlobalData.Instance.Exit(); }
        
}
