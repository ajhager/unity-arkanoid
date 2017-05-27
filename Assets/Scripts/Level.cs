using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private static int blockCount;
    private static int lifeCount;

	[RangeAttribute(1, 5)]
    public int lives = 3;

    void Start()
    {
        blockCount = 0;
        foreach (Transform block in transform)
        {
            blockCount += 1;
            iTween.MoveFrom(block.gameObject, iTween.Hash(
                "y", 7,
                "time", Random.Range(0.5f, 1f),
                "easeType", "easeOutElastic"
            ));
        }

        lifeCount = lives;
        GameObject.FindObjectOfType<Paddle>().LightUp(lifeCount);
    }

	public static void BallDied()
	{
        lifeCount -= 1;
        if (lifeCount <= 0)
        {
            LevelManager.Instance.LoadLevelSelect();
        }
		else
		{
            GameObject.FindObjectOfType<Paddle>().LightUp(lifeCount);
		}
    }

	public static void BlockDied()
	{
        blockCount -= 1;

        if (blockCount <= 0)
        {
            LevelManager.Instance.LoadLevelSelect();
        }
    }
}