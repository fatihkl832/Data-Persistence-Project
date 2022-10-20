using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuScript : MonoBehaviour
{

    public string tempname;
    public string saveName;

    public TextMeshProUGUI PrevBestScore;
    public string PrevName="";
    public int PrevScore=0;

    public void Awake()
    {

        PrevBestScore.text = "Best Score: " + SaveTheData.Instance.pName + " :" + SaveTheData.Instance.pScore;
    }

    public void EnterName(string a)
    {
       tempname = a;
        Debug.Log(tempname);   
        SaveTheData.Instance.tempName = tempname;
    }
   
    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }
 
}
