using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager Instance { get; private set; }

    public List<GameObject> obstaclePrefabs;

    public float obstacleSpeed = 10;

    public float obstacleInterval = 1;
    public Vector2 yOffset = new Vector2(0, 0);
    public float obstacleOffsetX = 0;

    [HideInInspector]

    public int score;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void EndGame()
    {
        isGameOver = true;


        StartCoroutine(ReloadScene(4));
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ReloadScene(float time)
    {
        yield return new WaitForSeconds(time);
     
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reloading Scene");
    }
}
