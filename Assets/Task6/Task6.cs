using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task6 : MonoBehaviour
{
    public void SaveAudioVolume(float volume) 
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SaveBestScore(int bestScore) 
    {
        PlayerPrefs.SetInt("bestScore",bestScore);
    }
}
