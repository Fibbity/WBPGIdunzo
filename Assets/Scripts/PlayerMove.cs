using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public AudioSource aSource;
    public AudioClip gemPickup;

    private ParticleSystem pSystem;

    float mx;

     void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        aSource = GetComponent<AudioSource>();
    }

    // Movement & quit game
    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    // Destroys gems, farts particles
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);

            pSystem.Play();

            aSource.PlayOneShot(gemPickup, 0.7F);
        }
    }
}
