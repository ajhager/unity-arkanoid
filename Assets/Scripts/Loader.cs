using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject levelManager;
    public GameObject soundManager;

    void Awake()
    {
        if (LevelManager.Instance == null)
        {
            Instantiate(levelManager);
        }

        if (SoundManager.Instance == null)
        {
            Instantiate(soundManager);
        }
    }
}