﻿using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    public AudioClip bounceSound;
    public AudioClip popSound;

    Rigidbody2D body;
    Rigidbody2D paddleBody;
    bool launched;
    float blockPitch;
    float blockTime;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        paddleBody = GameObject.Find("Paddle").GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        launched = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void Launch()
    {
        body.velocity = Vector2.up * speed;

        launched = true;
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Paddle")
        {
            float x = (transform.position.x - other.transform.position.x) / other.collider.bounds.size.x;
            Vector2 direction = new Vector2(x, 1).normalized;
            body.velocity = direction * speed;
            other.gameObject.GetComponent<Paddle>().Glow();
        }

        iTween.PunchScale(gameObject, Vector3.one, 0.5f);

        if (other.gameObject.tag == "Block")
        {
            PlayBlockSound();
        }
        else
        {
            SoundManager.Instance.Play(bounceSound, Random.Range(0.75f, 1.5f));
            Block.ShakeAll();
        }
    }

    void PlayBlockSound()
    {
        if (Time.time - blockTime < 1f)
        {
            blockPitch += 0.15f;
        }
        else
        {
            blockPitch = 1f;
        }

        SoundManager.Instance.Play(popSound, blockPitch);

        blockTime = Time.time;
    }

    void FixedUpdate()
    {
        if (!launched)
        {
            body.velocity = Vector2.zero;
            body.position = new Vector2(paddleBody.position.x, paddleBody.position.y + 0.3f);
            if (Input.GetButton("Fire1"))
            {
                Launch();
            }
        }
        else
        {
            if (Mathf.Abs(body.velocity.y) < Mathf.Epsilon)
            {
                body.velocity = Vector2.up * speed;
            }

            if (body.position.y <= -6)
            {
                Level.BallDied();
                Reset();
            }
        }
    }
}
