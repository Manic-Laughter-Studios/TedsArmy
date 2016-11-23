using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jackbed : MonoBehaviour {

    public int lives = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (lives <= 0)
        {
            SceneManager.LoadScene("KillScreen", LoadSceneMode.Additive); //loading killscreen on top
            Time.timeScale = 0;
        }
	}

    //for when reach Jack's bed
    void OnTriggerEnter(Collider other)
    {
        // If the enemy makes it to the end (hits end wall), it will destroy enemy and subtract a life
        if (other.gameObject.tag == "Enemy")
        {
            lives -= 1;
            Destroy(other.gameObject);
        }
    }
}
