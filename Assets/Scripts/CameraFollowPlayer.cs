using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range (0.0f, 1.0f)]
    public float smoothFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);


        //transform.position = newPosition;


    }
}
