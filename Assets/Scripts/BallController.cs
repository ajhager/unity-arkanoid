using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed = 10;

    private new Rigidbody2D rigidbody2D;
    private Rigidbody2D paddle;
    private bool launched = false;

	void Awake()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle").GetComponentInChildren<Rigidbody2D>();
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
		rigidbody2D.velocity = Vector2.up * speed;
        launched = true;
        GetComponent<TrailRenderer>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (launched && other.gameObject.tag == "Player")
        {
			float x = (transform.position.x - other.transform.position.x) / other.collider.bounds.size.x;
            Vector2 direction = new Vector2(x, 1).normalized;
            rigidbody2D.velocity = direction * speed;
        }

        iTween.PunchScale(gameObject, Vector3.one, 0.5f);
		foreach (BlockController block in GameObject.FindObjectsOfType<BlockController>())
        {
            block.Shake();
        }
    }

	void FixedUpdate()
	{
		if (!launched)
		{
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.position = new Vector2(paddle.position.x, paddle.position.y + 0.35f);
			if (Input.GetButton("Fire1"))
			{
                Launch();
            }
		}
	}
}
