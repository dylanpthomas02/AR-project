using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public ParticleSystem muzzleFlash;
    public float bulletForce = 30000f;

    GameObject arCamera;

    private void Awake()
    {
        arCamera = Camera.main.gameObject;
    }

    public void ShootProjectile()
    {
        FindObjectOfType<AudioManager>().Play("PlayerShoot");

        muzzleFlash.Play();

        Rigidbody newBullet = Instantiate(bullet, arCamera.transform.position, arCamera.transform.rotation);
        newBullet.AddForce(arCamera.transform.forward * bulletForce * Time.deltaTime);

        Destroy(newBullet.gameObject, 3f);
    }
}