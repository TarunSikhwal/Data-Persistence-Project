using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string hname;
        public int hscore;
    }

    public static GameManager Instance;
    public string hname;
    public int hscore;
    public string pname;
    public TextMeshProUGUI t;
    public TextMeshProUGUI tn;
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            tn.text = "High Score : " + data.hname + " : " + data.hscore;
            hname = data.hname;
            hscore = data.hscore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void insertname()
    {
        pname = t.text;
       
    }
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            tn.text = "High Score : "+ data.hname + " : " + data.hscore;
        }
    }
}
