using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RelativeVelCollision : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter targetParam;
    public string relVelName;

    public void SetAndTriggerParam(float paramValue)
    {
        targetParam.SetParameter(relVelName, paramValue);
        targetParam.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        SetAndTriggerParam(collision.relativeVelocity.magnitude/30) ;
    }
}