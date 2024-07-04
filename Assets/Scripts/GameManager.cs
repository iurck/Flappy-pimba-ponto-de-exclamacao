using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [FormerlySerializedAs("prefabs")]
    public List <GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float ObstacleOffsetX = 0;
    public Vector2 ObstacleOffsetY = new Vector2 (0, 0);

    [HideInInspector]
    public int score;
    private bool isGameOver = false;
    
    void Awake () // singleton (n lembro o que é rever depois)
    {
        if(Instance != null && Instance != this)
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
        //End game
        isGameOver = true;
        //Print Message
         Debug.Log("Game over... Your score was: " + score);
        //Reload Scene
        StartCoroutine(ReloadScene(2));
    }
    private IEnumerator ReloadScene(float delay )
    {
        //Wait
        yield return new WaitForSeconds(delay);

        //Reload Scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload Scene Please!!!!");
    }
}