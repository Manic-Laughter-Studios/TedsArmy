using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loadlevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }
	public void UILoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
	
}
