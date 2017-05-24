﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 10;

    private Rigidbody2D body;
    private Rigidbody2D paddleBody;
    private bool launched;

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
    }

	public void Launch()
	{
		body.velocity = Vector2.up * speed;
        launched = true;
        GetComponent<TrailRenderer>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (launched && other.gameObject.name == "Paddle")
        {
			float x = (transform.position.x - other.transform.position.x) / other.collider.bounds.size.x;
            Vector2 direction = new Vector2(x, 1).normalized;
            body.velocity = direction * speed;
        }

        iTween.PunchScale(gameObject, Vector3.one, 0.5f);
        Block.ShakeAll();
    }

	void FixedUpdate()
	{
		if (!launched)
		{
            body.velocity = Vector2.zero;
            body.position = new Vector2(paddleBody.position.x, paddleBody.position.y + 0.35f);
			if (Input.GetButton("Fire1"))
			{
                Launch();
            }
		}
	}
}