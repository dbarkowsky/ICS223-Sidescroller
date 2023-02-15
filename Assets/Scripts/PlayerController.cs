using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player controls
    [SerializeField] private Rigidbody rb;
    private float jumpForce = 12f;
    private bool grounded = true;

    // Game Manager
    [SerializeField] private GameManager gameManager;

    // Animations
    [SerializeField] private Animator anim;
    private bool dead = false;

    // Effects
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded && !dead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dirtParticle.Play();
        } else if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.EndGame();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 2);
            dead = true;
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
