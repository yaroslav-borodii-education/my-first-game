using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Task5_2 : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; 

	public void StartPause() 
	{
        print(1);
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void EndPause() 
	{
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void OpenMenu()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
