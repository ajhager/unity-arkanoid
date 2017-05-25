using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource effects;
    public AudioSource music;
     
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
 
        Instance = this;
 
        DontDestroyOnLoad(gameObject);
    }
 
	public void Play(AudioClip clip, float pitch = 1)
    {
        effects.pitch = pitch;
        effects.clip = clip;
        effects.Play();
    }
}
