using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadLevelSelect();
        }
    }

    public void Select(string name)
    {
        SceneManager.LoadScene("Level");
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
