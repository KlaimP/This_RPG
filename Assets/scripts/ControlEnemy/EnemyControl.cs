using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject Player;
    public SpriteRenderer HPenemy;
    public GameObject HPEnemyT;
    public float speed;
    [SerializeField] public float HPEnem;
    private Vector2 moveVelocity;
    private Vector3 change;
    private Rigidbody2D rb;
    private Animator animator;
    Transform playerT;
    public bool Angry = false;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        HPenemy.drawMode = SpriteDrawMode.Tiled;
        HPEnem=100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2();

        moveVelocity = moveInput.normalized * speed; 
        
        change = Vector3.zero;
    
        HPenemy.size = new Vector2(HPEnem/16,6);

        if(HPEnem<=0)
        {
            Destroy(gameObject);
        }
        
        if (change == Vector3.zero)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetFloat("movex", change.x);
            animator.SetFloat("movey", change.y);
            animator.SetBool("moving", true);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity*Time.fixedDeltaTime);
        if(Angry==true)
        {
        transform.position = Vector3.MoveTowards(transform.position, playerT.position, speed*Time.fixedDeltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
        HPEnemyT.SetActive(true);
        Angry = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        HPEnemyT.SetActive(false);
    }

    public void TakeDamage(int damage){
        HPEnem -= damage;
    }
}
