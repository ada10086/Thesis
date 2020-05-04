using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFormIAudioForCamAnimation : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Mobius Strip").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAudio(){
        audioSource.Play(0);
    }
}
