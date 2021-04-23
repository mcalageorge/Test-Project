using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    public AudioClip[] clips;

    AudioSource aus;

    // Start is called before the first frame update
    void Start()
    {
        aus = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlayAudioOneShot(AudioClip clip)
    {
        aus.PlayOneShot(clip, 0.3f);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
