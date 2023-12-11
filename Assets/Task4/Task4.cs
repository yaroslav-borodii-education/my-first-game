using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4 : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start() 
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
