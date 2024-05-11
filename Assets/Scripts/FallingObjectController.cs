using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb2d.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("DeadZone"))
        {
            GameManager.Instance.DecrementScore();
        }else if (collider.gameObject.CompareTag("Spike"))
        {
            audioSource.Play();
            GameManager.Instance.DecrementScore();
            Destroy(this.gameObject);
        }
    }
}
