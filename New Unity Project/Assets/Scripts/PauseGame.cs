using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public GameObject pauseButton;

	public void Pause()
    {
        Time.timeScale = 0;
        
    } 
    public void UnPause()
    {
        Time.timeScale = 1;
    }   
}
