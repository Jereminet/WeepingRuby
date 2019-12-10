using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instance;

    [HideInInspector]
    public float soundSize;
    public float deaths = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            //s.source.spatialBlend = 1;
        }
    }

    void Start()
    {
        Play("Theme");
        Play("heartbeat");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    public void ChangeVolume(string n, float v)
    {
        Sound s = Array.Find(sounds, sound => sound.name == n);
        if (s == null) return;
        s.source.volume = v;
    }

    public void setSound(float s)
    {
        soundSize = s;
    }

    public float getSound()
    {
        return soundSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ping()
    {
        Debug.Log("I was Pinged");
    }

    public float getDeaths()
    {
        return deaths;
    }
    public void die()
    {
        deaths = deaths + 1;
    }
}
