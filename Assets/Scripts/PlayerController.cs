using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Jump Variables
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpPower;
    float targetMoveSpeed;

    //isGrounded
    public bool isGrounded;
    public LayerMask groundLayers;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //IsGrounded?
         isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
              new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayers);

        //Movement of the player
        targetMoveSpeed = Mathf.Lerp(rb.velocity.x, Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, Time.deltaTime * 10);
        rb.velocity = new Vector2(targetMoveSpeed, rb.velocity.y);

        // Jump
        if (Input.GetKeyDown (KeyCode.Space) && isGrounded)  {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
	}
}
