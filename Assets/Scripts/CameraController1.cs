using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    CinemachineCameraOffset vcam1;
    Animator m_anim;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    public void CrouchCamera()
    {
        Debug.Log("Croucing");
        vcam1.m_Offset.y = 0.7f;
        //m_anim.SetBool("Crouch",true);
    }
    public void CameraStand()
    {
        Debug.Log("Stand Up");
        //m_anim.SetBool("Crouch 0", false);
    }
}
