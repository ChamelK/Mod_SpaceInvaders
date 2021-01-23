using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    public int scoreValue;

    public const float Max_Left = -6f;
    private float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x <= Max_Left)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        UIManager.UpdateScore(scoreValue);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
