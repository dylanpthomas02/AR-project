using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int playerHealth;

    Slider healthSlider;

    int damageAmount = 15;

    private void Start()
    {
        playerHealth = 100;
        healthSlider = GameObject.FindWithTag("Ui").GetComponentInChildren<Slider>();
        healthSlider.value = playerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            FindObjectOfType<AudioManager>().Play("TakeDamage");

            Damage(damageAmount);

            Destroy(other.gameObject);
        }
    }

    public void Damage(int amount)
    {
        playerHealth -= amount;
        healthSlider.value = playerHealth;

        if (playerHealth <= 50)
        {
            healthSlider.GetComponentInChildren<Image>().color = Color.red;
        }
        if (playerHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}