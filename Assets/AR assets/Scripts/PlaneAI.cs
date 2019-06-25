using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAI : MonoBehaviour
{
    [SerializeField]
    public Rigidbody projectile;

    public GameObject ps;
    ParticleSystem psSystem;
    float velocityMultiplier = 0.2f;
    float planeSpeed = 1f;
    Transform arCamera;
    int scoreIncrement = 1;

    float startDelay = 2f;
    float intervalDelay = 10f;

    void Awake()
    {
        ps = Instantiate(ps, transform.position, transform.rotation);
        psSystem = ps.GetComponent<ParticleSystem>();
        arCamera = Camera.main.gameObject.transform;
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Flying");
        StartCoroutine(Shoot());
    }

    void Update()
    {
        if (Player.playerHealth > 0 && GameManager.instance.gameHasEnded != true)
        {
            UpdatePosition();
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("Flying");
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (var bullet in bullets)
            {
                Destroy(bullet);
            }

            Destroy(gameObject);
        }
    }

    void UpdatePosition()
    {
        // Vector3 that points from plane to camera
        Vector3 relativePos = arCamera.position - transform.position;
        // Quaternion that faces that direction
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        // Current rotation
        Quaternion current = transform.rotation;
        // Interpolate from current rotation to new rotation
        transform.rotation = Quaternion.Slerp(current, rotation, Time.deltaTime * 100);
        // Circle the player as plane is always facing the camera
        transform.Translate(planeSpeed * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");

            psSystem.transform.position = transform.position;
            psSystem.Play();

            ScoreManager.instance.IncrementScore(scoreIncrement);
            Destroy(other.gameObject);
            Destroy(gameObject); 
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(startDelay);

        while (Player.playerHealth > 0 && GameManager.instance.gameHasEnded != true)
        {
            FindObjectOfType<AudioManager>().Play("EnemyShoot");

            Vector3 incomingVector = arCamera.transform.position - transform.position;

            Rigidbody enemyBullet = Instantiate(projectile, transform.position, transform.rotation);
            enemyBullet.velocity = incomingVector * velocityMultiplier;

            yield return new WaitForSeconds(intervalDelay);
        }
    }
}