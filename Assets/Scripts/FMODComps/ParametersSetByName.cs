using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersSetByName : MonoBehaviour
{
    FMOD.Studio.EventInstance WindChimeToneSoundC;

    //[FMODUnity.EventRef]
    //public string fmodEvent = null;

    //[SerializeField]
    //private string[] collisionTag = null;

    [SerializeField]
    private bool useParameter;

    //[SerializeField]
    //private string parameterName;



    private void Start()
    {
        
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        // float tempVolume = collision.relativeVelocity.magnitude / 20;
        float tempVolume;
        tempVolume = collision.relativeVelocity.magnitude;

        WindChimeToneSoundC = FMODUnity.RuntimeManager.CreateInstance("event:/WindChimeToneC");
        //WindChimeToneSoundC.setParameterByName("relativeVelocity", tempVolume);

        if (useParameter)
        {
            WindChimeToneSoundC.setParameterByName("relativeVelocity", tempVolume);
        }

        WindChimeToneSoundC.start();
        WindChimeToneSoundC.release();
        Debug.Log(tempVolume);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.name == "FPSController")
    //        WindChimeToneSoundC.setParameterByName("Ambience Fade", 0f);
    //}
}