using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    // RB is defined.
    public Rigidbody2D rb;
    //Integers are defined.
    public int speed;
    //Animator is defined.
    public Animator animator;
    //Instancing the player to prevent duplicates.
    public static characterScript instance;

    
    public string areaTransitionName;

    void Start()
    {
        if(instance == null)
        {
            //Instance if null.
            instance = this;
        }
        else
        {
            //Destroy duplicate if instance exists.
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))*speed;
        
        if(rb.velocity.x!=0||rb.velocity.y!=0)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
    }
}
