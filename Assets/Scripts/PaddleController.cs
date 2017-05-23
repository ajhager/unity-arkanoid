using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
	public float speed = 150;

    private new Rigidbody2D rigidbody2D;

    void Awake()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
	{
		float direction = Input.GetAxisRaw("Horizontal");

        rigidbody2D.velocity = Vector2.right * direction * speed * Time.fixedDeltaTime;
    }
}
