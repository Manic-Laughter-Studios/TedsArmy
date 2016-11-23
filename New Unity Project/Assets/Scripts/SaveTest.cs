using UnityEngine;
using System.Collections;

public class SaveTest : MonoBehaviour {

    public SimpleLevelSaveData saveData;

    static public SaveTest inst;

    public bool willSaveInStart = false, shouldSaveOnExit = true;


    public string SaveFileLocation 
    {
        get
        {
            return Application.persistentDataPath + "\\" + "SimpleLevelSaveData.json";
        }
    }

    void Awake()
    {
        if (inst != null)
            DestroyImmediate(this);

        inst = this;
    }

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        LoadScores();

        if(willSaveInStart)
            SaveScores();
	}

    void OnDestroy()
    {
        if (shouldSaveOnExit)
            SaveScores();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveScores()
    {
        //where is it going
        var loc = SaveFileLocation;

        //put into format
        var jsonData = JsonUtility.ToJson(saveData);

        //push to disk
        System.IO.File.WriteAllText(loc, jsonData);
    }

    public void LoadScores()
    {
        //where is it?
        var loc = SaveFileLocation;

        //load from disk
        var contents = System.IO.File.ReadAllText(loc);

        //push into our format
        JsonUtility.FromJsonOverwrite(contents, saveData);
    }
}
