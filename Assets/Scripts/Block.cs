using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;

    Vector3 startingPosition;

    void Awake()
    {
        startingPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            life -= 1;
            if (life <= 0)
            {
                Destroy(gameObject);
                Level.BlockDied();
            }
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
        foreach (Block block in FindObjectsOfType<Block>())
        {
            block.Shake();
        }
    }
}