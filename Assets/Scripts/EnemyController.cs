using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 1f;
    public float maxSpeed = 1f;


    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        rb2d.AddForce(Vector2.right * speed );

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);

        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f )
        {
            speed = -speed;

            rb2d.velocity = new Vector2(speed , rb2d.velocity.y);
        }



        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
          

            if(transform.position.y < collision.transform.position.y)
            {
                collision.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {
                collision.SendMessage("EnemyKnockBack",transform.position.x);
            }
            
        }
    }
}
