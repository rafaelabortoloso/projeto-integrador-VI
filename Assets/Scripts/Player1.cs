using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Player : Characters
{

    [SerializeField]
    
    private Rigidbody2D rg;
    public Animator animator;
    public float speed;
    private bool isAttacking;
    public GameObject Fireball;
    public float cooldown;
    private float lastAttack;
    public int lifes;
    private int remainingLifes;
    public GameObject score;
    public Slider slider;
    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        remainingLifes = lifes;
        isAttacking = false;
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        slider.value = this.lifes;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        var currentl =this.transform.position;
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var attack = Input.GetAxis("Jump");
        if(lastAttack+cooldown<=Time.time)
        {
            isAttacking = false;
        }

        if (attack == 1 && !isAttacking)
        {
            lastAttack = Time.time;
            isAttacking=true;
            var Projectile = Instantiate(Fireball,this.transform.position,Quaternion.identity);
            Projectile.GetComponent<Fireball>().score = this.score;
            var fireballDirection = new Vector2(x, y);
            if (x==0 && y==0) 
            {
                fireballDirection = new Vector2(1, 0);
            }
            Projectile.transform.right = fireballDirection;
            Projectile.GetComponent<Fireball>().direction = fireballDirection;

        }
        if (x != 0 || y != 0)
        {
            animator.SetBool("isMoving", true);
            var destiny = (Vector2)currentl + (new Vector2(x, y)) * speed * Time.deltaTime;
            rg.MovePosition(destiny);

        }
        else {
            animator.SetBool("isMoving", false);

        }

    }

    public void takeDamage()
    {
        remainingLifes--;
        slider.value = remainingLifes;
        if (remainingLifes <= 0)
        {
            Debug.Log("GameOver");
            manager.LoadGameOverScene();
        }
    }
}
