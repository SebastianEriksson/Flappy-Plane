using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private float upForce = 60f;                                                    // Define the amount of force the plane will go up with

    private bool isDead = false;                                                    // Plane isn't dead at start
    private Rigidbody2D rb2d;                                                       // Initialize the rigidbody
    private Animator anim;                                                          // Initialize the animator

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        // If the plane isn't dead do the following
        if (isDead == false)
        {
            // If the player presses their mouse1 button down, add upforce
            if (Input.GetMouseButtonDown(0))
            {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                    anim.SetTrigger("Fly");
            }
            // If the player touches their screen, add upforce
            if (Input.touchCount >= 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                    anim.SetTrigger("Fly");
                }
            }
        }

        // Add a up and down pitch for the plane
        transform.right = Vector2.Lerp(rb2d.velocity, Vector2.right, 0.75f);
    }

    // Custom physics
    private void FixedUpdate()
    {
        rb2d.AddForce(Vector2.down * 200f * Time.fixedDeltaTime);
    }

    // What to do when plane collides with something
    void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Crash");
        PlaneControll.instance.PlaneDied();
    }
}
