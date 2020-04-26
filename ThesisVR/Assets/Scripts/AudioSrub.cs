using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class AudioSrub : MonoBehaviour
{
    Granulator granulator;

    private GameObject physicsPointer;
    private Vector3 hitPointRelativeToTarget;
    private MeshRenderer meshRenderer;
    private float offsetX;
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
           
        hitPointRelativeToTarget = physicsPointer.GetComponent<PhysicsPointer>().hitPointRelativeToTarget;
        Debug.Log("hitPointRelativeToTarget"+ hitPointRelativeToTarget.x);

        offsetX = map(hitPointRelativeToTarget.x, -0.5f, 0.5f, 0.01f,1.01f);
        meshRenderer.material.SetVector("_Offset", new Vector2(offsetX, 0));

        float srubPos = map(hitPointRelativeToTarget.x, -0.5f, 0.5f, 0, 1);
        granulator.grainPos = srubPos;
        if (physicsPointer.GetComponent<PhysicsPointer>().targetIsHit){
            granulator.isPlaying = true;
        }else{
            granulator.isPlaying = false;
        }
    }

}

