using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake() {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        FindObjectOfType<AudioManager>().Play("BGM");
    }
   public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
   }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

 
}



[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 20f)]
    public float volume;
    [Range(0.1f,2f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
