/// Jonathan Lee 822937603
/// File: FurryController.cs
/// Last Updated: October 26th, 2015
/// Controls the movement and turning for the Player

using UnityEngine;
using System.Collections;

public class FurryController : MonoBehaviour {

	//Variables that shouldnt be changed manually, hidden to prevent inspector changing
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;


	//PUBLIC INSTANCE VARIABLES
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	//PRIVATE INSTANCE VARIABLES
	private bool grounded = true;
	private Animator anim;
	private Rigidbody2D rb2d;
	
	// Use this for initialization
	void Awake () {

		//Gets the Animator for the Player into variable
		anim = GetComponent<Animator> ();
		//Gets the RigidBody for the Player into variable
		rb2d = GetComponent<Rigidbody2D> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		//Sets a linecast for the Player to see if on platforms(ground) or not
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		//Condition when Player is on the ground
		if (grounded)
		{
			//Set the animation state to 0 that is idle
			anim.SetInteger("AnimState", 0);
		}

		//Condition when space bar pressed that is inititally on the ground
		if (Input.GetKeyDown("space") && grounded)
		{
			//Sets jump to true so that jump is possible
			jump = true;
			//Sets jump to false as no longer grounded
			grounded = false;
			//Animation State has moved to the 1st state that is jumping
			anim.SetInteger("AnimState", 1);
		}
	}


	void FixedUpdate()
	{
		//Horizontal returns a 0 to 1 floating point number, set it to h
		float h = Input.GetAxis ("Horizontal");
		//set absolute value of speed from anim
		anim.SetFloat ("Speed", Mathf.Abs (h));
		//Condition to add move force
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce (Vector2.right * h * moveForce);
		//Condition to set velocity
		if(Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		
		//Condition to allow turning
		if(h > 0 && !facingRight)
			
			Flip();
		
		else if(h < 0 && facingRight)
			
			Flip ();
		
		if (jump)
		{
			//anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
		
	}

	//Method to flip or mirror the player
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}