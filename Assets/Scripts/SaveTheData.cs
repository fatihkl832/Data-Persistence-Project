using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SaveTheData : MonoBehaviour
{
    public static SaveTheData Instance;

    public string pName="";
    public int pScore=0;
    public string tempName;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [System.Serializable]
    class SaveThemAll
    {
        public string Name;
        public int Score;
    }
    public void SaveData()
    {
       SaveThemAll data=new SaveThemAll();
        data.Name = pName;
        data.Score = pScore;

        string json=JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json=File.ReadAllText(path);
            SaveThemAll data = JsonUtility.FromJson < SaveThemAll > (json);

            pName= data.Name;
            pScore= data.Score;

        }
    }
}
