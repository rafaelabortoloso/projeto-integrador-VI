using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public GameObject score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition((Vector2)this.transform.position + (direction * speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            score.GetComponent<Score>().IncrementScore();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
