using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    private new Rigidbody2D rigidbody2D;

    void Awake()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
	{
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float squish = 1 + Mathf.Abs(mouse.x - transform.position.x);
        transform.localScale = new Vector3(squish * 2f, 1.25f / squish, 1);
        rigidbody2D.position = new Vector2(mouse.x, rigidbody2D.position.y);
    }
}
