using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormIAnimator : MonoBehaviour
{
    private AudioSource audioSource;
    private float formIYRotation;
    private float formIAnchorXRotation;
    private float formIAnchorZPosition;
    private GameObject FormI = GameObject.Find("FormI");
    private GameObject FormIAnchor = GameObject.Find("FormIAnchor");
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    private Vector3 formIAnchorPosition0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Form I new new").GetComponent<AudioSource>();
        formIAnchorPosition0 = GetComponent<Transform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        formIYRotation = map(audioSource.time, 0, audioSource.clip.length, 0.0F, -720.0F);
        FormI.transform.localEulerAngles = new Vector3(0,formIYRotation,0);
        
        
        formIAnchorXRotation = map(audioSource.time, 0, audioSource.clip.length, 0.0F, -360.0F);
        FormIAnchor.transform.localEulerAngles = new Vector3(formIAnchorXRotation,180,0);

        if(audioSource.time <= audioSource.clip.length*0.5){
            formIAnchorZPosition = map(audioSource.time, 0, audioSource.clip.length*0.5F, -1.23F, -4.4F);
        } else {
            formIAnchorZPosition = map(audioSource.time, audioSource.clip.length*0.5F, audioSource.clip.length, -4.4F, -1.23F);
        }
        FormIAnchor.transform.localPosition = new Vector3(-1.92F,5.94F,formIAnchorZPosition);
    }
}
