using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2f;
    public float maxSpeed = 5f;
    public bool grounded;
    public float jumpPower = 6.5f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private bool doubleJump;
    private SpriteRenderer spr;
    private bool movement = true;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        spr = GetComponent<SpriteRenderer>();

        


        
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));




        //Si tocamos el Suelo


        anim.SetBool("Grounded", grounded);


        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {

            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }else if (doubleJump)
            {
                jump = true;
                doubleJump = false;

            }

        }

        
        
    }


    private void FixedUpdate()
    {


        Vector3 fixedVelocity = rb2d.velocity;

        fixedVelocity.x *= 0.75f;



        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        //Reconoce las teclas A , D , LeftArrow <- , RightArrow ->

        float h = Input.GetAxis("Horizontal");


        if (!movement) h = 0;


        rb2d.AddForce(Vector2.right * speed * h );





        //if(rb2d.velocity.x > maxSpeed)
        //{
        //    rb2d.velocity = new Vector2(maxSpeed , rb2d.velocity.y);
        //}

        //if (rb2d.velocity.x < -maxSpeed)
        //{
        //    rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        //}


        //TODO Investigar CLAMP 
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x , -maxSpeed , maxSpeed);

        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);


        if ( h > 0.1f )
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if ( h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x , 0 );
            rb2d.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);
            jump = false;
        }


        //Debug.Log(rb2d.velocity.x);

    }


     void OnBecameInvisible()
    {
        transform.position = new Vector3(0, 0, 0); 
    }



    public void EnemyJump()
    {
        jump = true;
    }

    public void EnemyKnockBack(float enemyPositionx)
    {
        jump = true;

        float direction = Mathf.Sign(enemyPositionx - transform.position.x);
        rb2d.AddForce(Vector2.left * direction * jumpPower, ForceMode2D.Impulse);

        Color colorRojo = new Color(255/255f, 106/255f, 0f);
        spr.color = colorRojo; 

        movement = false;

        Invoke("EnableMovement", 0.8f );

    }



    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    } 
}
