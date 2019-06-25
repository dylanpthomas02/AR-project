using System;
using UnityEngine;

//Call with: FindObjectOfType<AudioManager>().Play("NameInInspector");

[Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 0.25f;
    [Range(.1f, 3f)]
    public float pitch = 1f;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
}