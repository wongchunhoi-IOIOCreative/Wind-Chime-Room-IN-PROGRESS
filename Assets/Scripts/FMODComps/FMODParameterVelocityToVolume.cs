using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODParameterVelocityToVolume : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emitter;
    //[FMODUnity.ParamRef]
    //public string MyParam1;

    [SerializeField]
    private string relativeVeolocityParameterName = "relativeVelocity";
    [SerializeField]
    [Range(0, 1)]
    private float relativeVeolocityParameter;
        
    float InstantVelocityToVolume; 

    void OnEnable()
    {
        var target = GameObject.Find("NameOfEmitterObject");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        //float value = 1.0f; // calculate the value every frame
        emitter.SetParameter("relativeVelocity", InstantVelocityToVolume);
    }

    void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        if (collision.relativeVelocity.magnitude > 0.1)
        {
            InstantVelocityToVolume = collision.relativeVelocity.magnitude / 20;
            
        }

    }
}
