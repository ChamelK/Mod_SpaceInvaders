using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ShipStats shipStats;

    public GameObject bulletPrefab;

    private Vector3 offScreenPos = new Vector3(0, -20f);
    private Vector3 startPos = new Vector3(0, 0, 15f);

    public const float Max_Left = -14.0f;
    public const float Max_Right = 14.0f;


    private bool isShooting;

    // Start is called bef ore the first frame update
    void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives;

        transform.position = startPos;

        UIManager.UpdateHealthBar(shipStats.currentHealth);
        UIManager.UpdateLives(shipStats.currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > Max_Left)
            transform.Translate(Vector3.left * Time.deltaTime * shipStats.shipSheed);


        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < Max_Right)
            transform.Translate(Vector3.right * Time.deltaTime * shipStats.shipSheed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());

    }

    private void TakeDamage()
    {
        shipStats.currentHealth--;
        UIManager.UpdateHealthBar(shipStats.currentHealth);

        if(shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;
            UIManager.UpdateLives(shipStats.currentLives);


            if (shipStats.currentLives <= 0)
            {
                Debug.Log("Game Over");
                //Game Over
            }
            else
            {
                StartCoroutine(Respawn());
            }
        }

    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;

        transform.position = startPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("PlayerHit");
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
