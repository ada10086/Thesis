using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormIAnchorAnimator : MonoBehaviour
{
    private AudioSource audioSource;
    private float formIAnchorXRotation;
    private float formIAnchorZPosition;
    // private float formIAnchorXRotation0;
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("FormI new new").GetComponent<AudioSource>();
        // formIAnchorXRotation0 = GetComponent<Transform>().localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {

        formIAnchorXRotation = map(audioSource.time, 0, audioSource.clip.length, 90, 90+360.0F);
        this.transform.localEulerAngles = new Vector3(formIAnchorXRotation,0,0);

        if(audioSource.time <= audioSource.clip.length*0.5){
            // formIAnchorZPosition = map(audioSource.time, 0, audioSource.clip.length*0.5F, -2F, -6F);
            formIAnchorZPosition = map(audioSource.time, 0, audioSource.clip.length*0.5F, 2F, -2F);

        } else {
            // formIAnchorZPosition = map(audioSource.time, audioSource.clip.length*0.5F, audioSource.clip.length, -6F, -2F);
            formIAnchorZPosition = map(audioSource.time, audioSource.clip.length*0.5F, audioSource.clip.length, -2F, 2F);

        }
        this.transform.localPosition = new Vector3(5F,5F,formIAnchorZPosition);
    }
}
