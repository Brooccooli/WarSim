using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    private int speed = 10;
    private float aliveTimer = 5;

    void Start()
    {
        transform.Rotate(new Vector3(0, 0, -90));
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        aliveTimer -= Time.deltaTime;
        if (aliveTimer > 0)
        {
            return;
        }
        if (!GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
