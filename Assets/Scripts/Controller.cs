using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private float horizontalinput;
    private float speed = 11f;
    private float jumpingPower = 18f;
    private int jumpsRemaining;
    private bool lockedMovement = false;
    [SerializeField] public float delayBetweenJumps = 0.4f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
    horizontalinput = Input.GetAxisRaw("Horizontal"); 
       
        //Ground Check
        if(isGrounded())
        {
            jumpsRemaining = 1;
        }

        //Jump Code
        if (jumpsRemaining>0 && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            jumpsRemaining--;
        }

        //Stomp Code
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            StartCoroutine(JumpSequence());
           
        }
    }
        

    private void FixedUpdate()
    {
        //Left/Right Movement code
        if(lockedMovement == false)
        {
            rb.velocity = new Vector2(horizontalinput * speed, rb.velocity.y);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.9f, groundLayer);
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }



    IEnumerator JumpSequence()
    {
        lockedMovement = true;

        rb.velocity = new Vector2(0, jumpingPower);
        while (isGrounded() == false)
        {
            yield return new WaitForSeconds(delayBetweenJumps);
            rb.velocity = new Vector2(0, -25f);
        }

        lockedMovement = false;
    }

}
