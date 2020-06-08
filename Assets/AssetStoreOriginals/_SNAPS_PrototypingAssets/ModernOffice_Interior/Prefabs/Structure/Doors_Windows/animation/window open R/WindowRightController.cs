using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowRightController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator m_Animator;
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Animator.SetTrigger("WindowOpenClose");
        }

    }
}
