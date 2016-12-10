using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    //movement variable
    public float maxSpeed;
    float speed;

    //jumping variable
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight, Jumping;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
	}
	
	// Update is called once per frame
    void Update() {
        MovePlayer(speed);

        flip();

        // left player movement
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            speed = -maxSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)){
            speed = 0;
        }
        //

        // right player movement
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            speed = maxSpeed;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)){
            speed = 0;
        }
        //

        //player jumping
        if (grounded && Input.GetKeyDown(KeyCode.S)){
            jump();
        }

        //player shooting
        if(Input.GetKeyDown(KeyCode.A)) {
            fireRocket();
        }
    }

	void FixedUpdate () {
        //check if we are grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        //myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move>0 && !facingRight) {
            flip();
        }else if(move<0 && facingRight) {
            flip();
        }
	}

    void MovePlayer(float playerSpeed)
    {
        // code for player movement
        
        if (playerSpeed < 0 && !Jumping || playerSpeed > 0 && !Jumping)
        {
            myAnim.SetInteger("State", 1);
        }
        if (playerSpeed == 0 && !Jumping)
        {
            myAnim.SetInteger("State", 0);
        }

        myRB.velocity = new Vector3(speed, myRB.velocity.y, 0);
    }

    void flip() {
        if (speed > 0 && !facingRight || speed < 0 && facingRight){
            facingRight = !facingRight; 
            Vector3 theScale = transform.localScale; 
            theScale.x *= -1; 
            transform.localScale = theScale;
        }
    }

    public void jump() {
        grounded = false;
        myAnim.SetBool("isGrounded", false);
        myRB.AddForce(new Vector2(0, jumpHeight));
    }

    public void fireRocket() {
        if(Time.time > nextFire) {
            nextFire = Time.time+fireRate;
            if(facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(0, 0, 0));
            }else if(!facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(0, 0, 180f));
            }
        }
    }

    public void WalkLeft(){
        speed = -maxSpeed;
    }

    public void WalkRight(){
        speed = maxSpeed;
    }

    public void StopMoving(){
        speed = 0;
    }

}
