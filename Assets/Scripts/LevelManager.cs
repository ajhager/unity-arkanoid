using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public string[] levels;
    public int currentLevel;

    void Start()
	{
        SceneManager.LoadSceneAsync(levels[currentLevel], LoadSceneMode.Additive);
    }
}
