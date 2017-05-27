using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private static int blockCount;

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