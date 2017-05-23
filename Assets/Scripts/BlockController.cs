using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    Vector3 startingPosition;

	void Awake()
	{
        startingPosition = transform.position;
    }

    void Start()
	{
        iTween.MoveFrom(gameObject, iTween.Hash(
            "y", 7,
            "time", Random.Range(0.5f, 1f),
            "easeType", "easeOutElastic"
        ));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

	public void Shake()
    {
        iTween.Stop(gameObject);
        transform.position = startingPosition;
        iTween.ShakePosition(gameObject, Vector3.one * Random.Range(-0.2f, 0.2f), 0.2f);
    }
}
