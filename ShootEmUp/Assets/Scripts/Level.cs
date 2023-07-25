using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public static Level instance;

    uint numDestructables = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 4;

    string[] levels = { "Level1", "Level2" };
    int currentLevel = 1;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    Debug.Log("Game Over");
                }
                nextLevelTimer = 4;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddDestructables()
    {
        numDestructables++;
    }

    public void RemoveDestructables()
    {
        numDestructables--;

        if (numDestructables == 0)
        {
            startNextLevel = true;
        }
    }
}
