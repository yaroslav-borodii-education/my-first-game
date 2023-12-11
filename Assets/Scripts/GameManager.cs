using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private float spawnInterval = 2f;

    [SerializeField] private AudioSource audioSource;

    private float levelWidth;

    private void Start()
    {
        levelWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)).x;
        InvokeRepeating("SpawnObject", 0f, spawnInterval);

        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }

    private void SpawnObject()
    {
        float randomX = Random.Range(-levelWidth, levelWidth);
        Instantiate(eggPrefab, new Vector2(randomX, 5f), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Egg"))
        {
            Destroy(other.gameObject);
        }
    }
}
