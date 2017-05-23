using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public string[] levels;
    public int currentLevel;

    void Awake()
	{
        InitLevel();
    }
	
	void InitLevel()
	{
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
    }
}
