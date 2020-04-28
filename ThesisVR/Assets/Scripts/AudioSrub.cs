using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class AudioSrub : MonoBehaviour
{
    Granulator granulator;
    private GameObject physicsPointer;
    private Vector3 hitPointTargetLocalPos;
    private MeshRenderer meshRenderer;

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    void Start()
    {
        granulator = GetComponent<Granulator>();
        physicsPointer = GameObject.Find("PhysicsPointer");
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (physicsPointer.GetComponent<PhysicsPointer>().hitTarget == this.name){
            hitPointTargetLocalPos = physicsPointer.GetComponent<PhysicsPointer>().hitPointTargetLocalPos;
            // Debug.Log("hitPointTargetLocalPos"+ hitPointTargetLocalPos.x);

            //move shader highlight offset
            float offsetX = map(hitPointTargetLocalPos.x, -0.5f, 0.5f, 0.01f,1.01f);
            meshRenderer.material.SetVector("_Offset", new Vector2(offsetX, 0));

            //scrub audio
            float srubPos = map(hitPointTargetLocalPos.x, -0.5f, 0.5f, 0, 1);
            granulator.grainPos = srubPos;
            granulator.isPlaying = true;
        }else{
            granulator.isPlaying = false;
        }
    }

}

