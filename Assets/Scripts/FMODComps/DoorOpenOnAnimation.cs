using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenOnAnimation : MonoBehaviour
{
	
	[FMODUnity.EventRef]
	private string FMODEventName = "";

	public FMOD.Studio.EventInstance A_EventSound;

    //private void Awake()
    //{
        
    //}

    void PlaySoundOnAnimationEvent(string FMODEventName)
    {
        //A_EventSound = FMODUnity.RuntimeManager.CreateInstance(FMODEventName);
        FMODUnity.RuntimeManager.PlayOneShot(FMODEventName,transform.position);
        //FMOD.Studio.EventInstance.PlayOneShot(FMODEventName, transform.position);
    }
}
