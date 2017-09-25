using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPro : MonoBehaviour {

    Rigidbody2D body2d;
    public float jumpspeed = 240f;
    public float forwardSpeed = 20f;
    public float forward = 10f;
    public bool moving = false;
    public bool jumping = false;
    private Animator animate;
    public int gravityFactor = 90;
    private float oldpos;
    private bool standstate = true;
    public float velocity = 0;


    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        gravityFactor = 90;
       
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (body2d.velocity.magnitude < velocity && standstate==false)
        {

            standstate = true;
            animate.SetInteger("State", 1);
            animate.Play("Stand");
           // body2d.gravityScale = gravityFactor;
        }
        

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor" && jumping==true)
        {
            jumping = false;
            body2d.gravityScale = body2d.gravityScale*2;
            
            Physics.gravity = Physics.gravity * 2;

        }
            


    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow ) && jumping == false)
        {
           // moving = false;
            body2d.velocity = new Vector2(forwardSpeed,0);
            animate.SetInteger("State", 2);
            animate.Play("Run");
            standstate = false;
            
            // body2d.gravityScale = 10;

            //body2d.AddForce(transform.up * jumpspeed);
            //print("helo");
        }
        if (Input.GetKey(KeyCode.UpArrow) && jumping == false)
        {
            //Physics.gravity = Physics.gravity * 2;
            jumping = true;
           // body2d.gravityScale = 5;
            body2d.velocity = new Vector2(forward, jumpspeed);
            //body2d.AddForce(Vector3.up * jumpspeed * Time.deltaTime,ForceMode2D.Force);
            body2d.gravityScale = body2d.gravityScale/2;
            animate.SetInteger("State", 3);
            animate.Play("Jump");
            standstate = false;
        }
        // body2d.gravityScale = 5;
    }
}
