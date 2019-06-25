using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; }

    Text playerScoreText;

    public static int playerScore = 0;

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

        playerScore = 0;
    }

    public void IncrementScore(int amount)
    {
        playerScore += amount;
        UpdateScoreUI();

        if (playerScore >= 5)
        {
            // Destroy the bullets
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (var bullet in bullets)
            {
                Destroy(bullet);
            }
            // Destroy the planes
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Plane");
            foreach (var enemy in enemies)
            {
                FindObjectOfType<AudioManager>().Stop("Flying");
                Destroy(enemy);
            }

            GameManager.instance.LevelCompleteUI();
        }
    }

    public void UpdateScoreUI()
    {
        if (playerScoreText == null)
        {
            playerScoreText = GameObject.FindWithTag("PlayerScore").GetComponent<Text>();
        }

        playerScoreText.text = playerScore.ToString();
    }
}