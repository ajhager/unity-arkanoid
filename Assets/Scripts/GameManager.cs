using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public BoardManager board;

    private static string[] level1 = {
		"rrrrrrrrrr",
		"bbbbbbbbbb",
		"gggggggggg",
    };

    private static string[][] levels = {
		level1
    };

    private int levelIndex = 0;

    void Awake()
	{
        board = GetComponent<BoardManager>();
        InitLevel();
    }
	
	void InitLevel()
	{
        board.SetupScene(levels[levelIndex]);
    }
}
