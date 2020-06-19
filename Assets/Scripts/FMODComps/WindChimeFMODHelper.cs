using UnityEngine;///Reference https://www.fmod.com/resources/documentation-unity?version=2.0&page=examples-basic.html
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class WindChimeFMODHelper : MonoBehaviour
{
    private Rigidbody windChimeRB;    //--------------------------------------------------------------------
    // 1: Using the EventRef attribute will present the designer with
    //    the UI for selecting events.
    //--------------------------------------------------------------------
    [FMODUnity.EventRef]
    public string WindChimeEvtName = "";
    [SerializeField]
    private string relativeVelParam = "relativeVelocity";    //--------------------------------------------------------------------
    // 2: Using the EventInstance class will allow us to manage an event
    //    over it's lifetime. Including starting, stopping and changing 
    //    parameters.
    //--------------------------------------------------------------------
    FMOD.Studio.EventInstance windChimeState;
    private float relVel;
    FMOD.Studio.PARAMETER_ID relVelId;

    private void Awake()
    {
        windChimeRB = GetComponent<Rigidbody>();
    }
    private void OnDestroy()
    {
        StopAllEvents();
        //--------------------------------------------------------------------
        // 6: This shows how to release resources when the unity object is 
        //    disabled.
        //--------------------------------------------------------------------
        windChimeState.release();
    }
    private void CreateEventInstance()
    {
        //--------------------------------------------------------------------
        // 4: This shows how to create an instance of an Event and manually 
        //    start it.
        //--------------------------------------------------------------------
        windChimeState = FMODUnity.RuntimeManager.CreateInstance(WindChimeEvtName);        //--------------------------------------------------------------------
        //    Cache a handle to the "crazy" parameter for usage in Update()
        //    as shown in (9). Using the handle is much better for performance
        //    than trying to set the parameter by name every update.
        //--------------------------------------------------------------------
        FMOD.Studio.EventDescription WindChimeEvtNameDescription;
        windChimeState.getDescription(out WindChimeEvtNameDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION relVelParameterDescription;
        WindChimeEvtNameDescription.getParameterDescriptionByName(relativeVelParam, out relVelParameterDescription);
        relVelId = relVelParameterDescription.id;
    }
    public void SetRelativeVelocityAndStartEvent(float velocity)
    {
        if (windChimeState.isValid())
        {
            relVel = velocity;
            windChimeState.setParameterByID(relVelId, relVel);
            EmitWindChimeEvent();
        }
    }
    private void StopAllEvents()
    {
        windChimeState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    public void EmitWindChimeEvent()
    {
        windChimeState.start();
        windChimeState.release();
    }
    public void OnCollisionEnter(Collision collision)
    {
        CreateEventInstance();        //--------------------------------------------------------------------
        // 8: This shows how to manually update the instance of a 3D event so 
        //    it has the position and velocity of it's game object. (5) Show
        //    how this can be done automatically.
        //--------------------------------------------------------------------
        windChimeState.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, windChimeRB));
        float fmodVal = Mathf.Clamp01(collision.relativeVelocity.magnitude);
        SetRelativeVelocityAndStartEvent(fmodVal);
        Debug.Log(WindChimeEvtName + " 's FMOD Relative Velocity: " + fmodVal);
    }
}   