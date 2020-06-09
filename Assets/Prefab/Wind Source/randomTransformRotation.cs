using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTransformRotation : MonoBehaviour
{
    public float RandomAngleRange = 10.0f;
    private float RotationStep ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationStep = Random.Range(-(RandomAngleRange), RandomAngleRange);
        
        transform.Rotate(0, RotationStep, 0);
    }
}
