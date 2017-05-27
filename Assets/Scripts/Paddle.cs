using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    private Rigidbody2D body;
    public GameObject[] lights;

    void Awake()
	{
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
	{
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Scale based on velocity to provide a squishing effect.
        float squish = 1 + Mathf.Abs(mouse.x - transform.position.x);
        transform.localScale = new Vector3(1.5f * squish, 1.25f / squish, 1);

        // Follow the mouse on the x axis.
        body.position = new Vector2(mouse.x, body.position.y);
    }

    public void Glow()
    {
        iTween.ColorFrom(gameObject, Color.white, 0.33f);
    }

    public void LightUp(int lightCount)
    {
        for (var i = 0; i < lights.Length; i++)
        {
            if (i < lightCount)
            {
                lights[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                lights[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }
}
