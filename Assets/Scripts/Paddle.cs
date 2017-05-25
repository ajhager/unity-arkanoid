using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    private new Rigidbody2D rigidbody2D;

    void Awake()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
	{
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Scale based on velocity to provide a squishing effect.
        float squish = 1 + Mathf.Abs(mouse.x - transform.position.x);
        transform.localScale = new Vector3(1.5f * squish, 1.25f / squish, 1);

        // Follow the mouse on the x axis.
        rigidbody2D.position = new Vector2(mouse.x, rigidbody2D.position.y);
    }

    public void Glow()
    {
        iTween.ColorFrom(gameObject, Color.white, 0.33f);
    }
}
