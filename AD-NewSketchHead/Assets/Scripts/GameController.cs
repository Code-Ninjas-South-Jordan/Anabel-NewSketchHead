using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Platform Game Object")]
    public GameObject platform;
    [Header("Fake Platform")]
    public GameObject fakePlat;
    float pos = 0;
    [Header("Game Over UI Canvas")]
    public GameObject gameOverCanvas;
    void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            SpawnPlatforms();
        }
        pos = 0;
        for(int i = 0; i < 100; i++)
        {
            SpawnFakePlatforms();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnPlatforms()
    {
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 2.5f;
    }
    void SpawnFakePlatforms()
    {
        Instantiate(fakePlat, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 2.5f;
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}