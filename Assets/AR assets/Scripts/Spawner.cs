using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject prefabToSpawn;
    public Transform arCamera;

    float startDelay = 1f;
    float intervalDelay = 9f;

    void Start()
    {
        ScoreManager.instance.UpdateScoreUI();
        GameManager.instance.HideUI();
        GameManager.instance.ShowCrossHair();
        StartCoroutine(SpawnPlanes());
    }

    IEnumerator SpawnPlanes()
    {
        yield return new WaitForSeconds(startDelay);

        while (Player.playerHealth > 0 && GameManager.instance.gameHasEnded != true)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Instantiate(prefabToSpawn, spawnPoints[i].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(intervalDelay);
        }
    }
}