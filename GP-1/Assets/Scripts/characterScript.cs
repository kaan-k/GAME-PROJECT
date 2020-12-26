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

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    
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
            if(instance != this)
            {
                //Destroy duplicate if instance exists.
                Destroy(gameObject);
            } 
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,bottomLeftLimit.x,topRightLimit.x),Mathf.Clamp(transform.position.y,bottomLeftLimit.y,topRightLimit.y),transform.position.z);
    }
    public void SetBounds(Vector3 botLeft,Vector3 topRight)
    {
        //TUNING REQ!!!
        bottomLeftLimit = botLeft + new Vector3(0.1f,0.1f,0f);
        topRightLimit = topRight + new Vector3(-0.1f,-0.1f,0f);
    }

}
