using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RelativeVelCollision : MonoBehaviour
{
    [SerializeField]
    private StudioParameterTrigger targetParam;
    public EmitterRef targetEmitter;

    public void SetAndTriggerParam(float paramValue)
    {
        //targetParam. = paramValue;
        //targetParam.
        //targetParam.TriggerParameters();
    }

    public void OnCollisionEnter(Collision collision)
    {
        SetAndTriggerParam(collision.relativeVelocity.magnitude);
    }
}