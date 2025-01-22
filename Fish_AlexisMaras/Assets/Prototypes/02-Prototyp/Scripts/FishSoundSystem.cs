using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSoundSystem : MonoBehaviour
{
    public AudioSource idleSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayIdleSound()
    {
        idleSound.Play();
    }
}
