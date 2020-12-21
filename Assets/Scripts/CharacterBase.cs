using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour{

    public Rigidbody2D rb;
    public Animator animator;
    public string name;
    [SerializeField] float health;
    [SerializeField] int agility;
    [SerializeField] float damage;
    protected bool jumpSpecialityIsUsable = false;
    protected bool isJumped = false;
    bool isAttackable = true;
    bool facingLeft = false;
    public float horizontalInput;
    public bool jumpInput;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
        
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
        if (jumpSpecialityIsUsable == true && jumpInput)
        {
            jumpSpecially();
        }

        if (Input.GetButtonDown("Fire1") && isAttackable)
        {
            attack();
        }

        jump();
        move();
    }


    void jump()
    {
        if (jumpInput && isJumped == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);
            isJumped = true;
            jumpSpecialityIsUsable = true;
            animator.SetBool("isjumped", true);
            jumpInput = false;
        }

    }

    void move()
    {
        
        if (horizontalInput > 0 | horizontalInput < 0)
        {
            rb.velocity = new Vector2(Mathf.Sign(horizontalInput) * agility, rb.velocity.y);
            animator.SetFloat("speed", 1);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        if (Mathf.Abs(rb.velocity.x) < agility)
        {
            rb.velocity = new Vector2(0 , rb.velocity.y);
        }

        if (facingLeft == false && horizontalInput < 0)
        {
            flip();
        }
        else if (facingLeft == true && horizontalInput > 0)
        {
            flip();
        }
    }

    void flip()
    {
        facingLeft = !facingLeft;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void attack()
    {
        UnityEngine.Debug.Log("Attacked");
    }



    public virtual void jumpSpecially()
    {

    }

    void OnCollisionEnter2D()
    {
        isJumped = false;
        jumpSpecialityIsUsable = false;
        animator.SetBool("isjumped", false);
        animator.SetBool("isSpeciallyJumped", false);
    }

    public void setInput(int buttontype)
    {
        if (buttontype==0)
        {
            jumpInput =true;
        }
        else if (buttontype == 1)
        {
            jumpInput = false;
        }
        else if (buttontype == 2)
        {
            horizontalInput = 1;
        }
        else if (buttontype == 3)
        {
            horizontalInput = -1;
        }
        else if (buttontype == 4)
        {
            horizontalInput = 0;
        }
    }
}
