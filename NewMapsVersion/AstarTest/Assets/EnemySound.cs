using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemySound : MonoBehaviour
{
    public AudioSource beat;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Awake()
    {
        beat = GetComponent<AudioSource>();
        beat.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
