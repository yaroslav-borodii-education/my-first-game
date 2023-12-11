using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Task5_1 : MonoBehaviour
{  
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Slider _volumeSlider;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Task6 saveData;

    private static float _volume;

    private void Awake() 
    {
        if(!PlayerPrefs.HasKey("volume")) PlayerPrefs.SetFloat("volume", 1f);
        _volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void MenuButton(GameObject panel) 
    {
       _mainPanel.SetActive(false);
       panel.SetActive(true);
    }


    public void StartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetVolume(float volume)
    {
        _volume = volume;
        _audioSource.volume = volume;
        SaveVolume();
    }

    public void Cancel(GameObject panel)
    {
        panel.SetActive(false);
        _mainPanel.SetActive(true);
    }

    public void SaveVolume() 
    {
        saveData.SaveAudioVolume(_volume);
    }

    public void Quit() 
    {
        Application.Quit(); 
    }
}
