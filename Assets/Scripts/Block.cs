using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;

    private static int blockCount;
    private Vector3 startingPosition;

    void Awake()
    {
        startingPosition = transform.position;
        Block.blockCount += 1;
    }

    void Start()
    {
        DropFromSky();
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        life -= 1;
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        blockCount -= 1;
        if (blockCount <= 0)
        {
            LevelManager.Instance.LoadLevelSelect();
        }
    }

    void DropFromSky()
    {
        iTween.MoveFrom(gameObject, iTween.Hash(
            "y", 7,
            "time", Random.Range(0.5f, 1f),
            "easeType", "easeOutElastic"
        ));
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
