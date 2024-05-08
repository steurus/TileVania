using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives=3;
    [SerializeField] int score=0;
    [SerializeField] TextMeshProUGUI livestext;
    [SerializeField] TextMeshProUGUI scoretext;
 
    void Awake()
    {
        int numGameSession =FindObjectsOfType<GameSession>().Length;
        if(numGameSession>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }        
    }

    void Start()
    {
        livestext.text=playerLives.ToString();
        scoretext.text=score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives>1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score +=pointsToAdd;
        scoretext.text=score.ToString();
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livestext.text=playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
