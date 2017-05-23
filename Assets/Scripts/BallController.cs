using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed = 10;

    private new Rigidbody2D rigidbody2D;

	void Awake()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
	{
        rigidbody2D.velocity = Vector2.up * speed;
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
			float x = (transform.position.x - other.transform.position.x) / other.collider.bounds.size.x;
            Vector2 direction = new Vector2(x, 1).normalized;
            rigidbody2D.velocity = direction * speed;
        }
    }
}
