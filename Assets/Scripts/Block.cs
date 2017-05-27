using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;

    private Vector3 startingPosition;

    void Awake()
    {
        startingPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        life -= 1;
        if (life <= 0)
        {
            Destroy(gameObject);
            Level.BlockDied();
        }
    }

    public void Shake()
    {
        iTween.Stop(gameObject);
        transform.position = startingPosition;
        iTween.ShakePosition(gameObject, Vector3.one * Random.Range(-0.2f, 0.2f), 0.2f);
    }

    public static void ShakeAll()
    {
        foreach (Block block in GameObject.FindObjectsOfType<Block>())
        {
            block.Shake();
        }
    }
}