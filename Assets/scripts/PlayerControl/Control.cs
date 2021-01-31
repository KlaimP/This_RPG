using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    
    public float speed;
    public Image HealthBar;
    public Text HPt;
    public Image ManaBar;
    public Text MPt;
    public float HP, Mana;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector3 change;
    private Animator animator;
    private float hpK, mpK;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        HP = 100f;
        hpK = HP;
        Mana = 100f;
        mpK = Mana;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {      
    HealthBar.fillAmount = HP / hpK;  //Для получение 1
        if(HP<0)
        {
            HP=0;
        }
        else if(HP > hpK)
        {
            HP=hpK;
        }
        
        if(Mana<0)
        {
            Mana=0;
        }
        else if(Mana > mpK)
        {
            Mana=mpK;
        }
        ManaBar.fillAmount = Mana / mpK;
        HPt.text = HP.ToString("f0") + "/" + hpK.ToString("f0");
        MPt.text = Mana.ToString("f0") + "/" + mpK.ToString("f0");

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed; 
        
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change == Vector3.zero)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity*Time.fixedDeltaTime);
    }

}
