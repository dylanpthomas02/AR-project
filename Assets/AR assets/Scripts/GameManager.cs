using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject levelCompletePanel;
    GameObject crossHair;

    [HideInInspector]
    public bool gameHasEnded = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ShowUI()
    {
        if (levelCompletePanel == null)
        {
            levelCompletePanel = GameObject.FindWithTag("LevelComplete");
            levelCompletePanel.SetActive(true);
        }
        else
        {
            levelCompletePanel.SetActive(true);
        }   
    }

    public void HideUI()
    {
        if (levelCompletePanel == null)
        {
            levelCompletePanel = GameObject.FindWithTag("LevelComplete");
            levelCompletePanel.SetActive(false);
        }
        else
        {
            levelCompletePanel.SetActive(false);
        }
    }

    public void ShowCrossHair()
    {
        if (crossHair == null)
        {
            crossHair = GameObject.FindWithTag("CrossHair");
            crossHair.SetActive(true);
        }
        else
        {
            crossHair.SetActive(true);
        }
    }

    public void HideCrossHair()
    {
        crossHair.SetActive(false);
        gameHasEnded = false;
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            HideCrossHair();
            ShowUI();
            levelCompletePanel.GetComponent<Animator>().SetTrigger("LevelComplete");
            GameObject.FindWithTag("NextLevelButton").SetActive(false);
        }
    }

    public void LevelCompleteUI()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            HideCrossHair();
            ShowUI();
            levelCompletePanel.GetComponent<Animator>().SetTrigger("LevelComplete");
        }
    }

    public void StartNextLevel()
    {
        ScoreManager.playerScore = 0;
        Player.playerHealth = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        ScoreManager.playerScore = 0;
        Player.playerHealth = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}