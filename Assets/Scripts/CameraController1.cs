using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController1 : MonoBehaviour
{
    CinemachineCameraOffset vcam1;
    Vector3 cameraOffset;
    [SerializeField] GameObject player;
    //Animator m_anim;
    //[SerializeField] CinemachineVirtualCamera vcam;

    private void Start()
    {
        player.GetComponent<Transform>();
        vcam1 = GetComponent<CinemachineCameraOffset>();
        //m_anim = GetComponent<Animator>();
    }

    public void CrouchCamera()
    {
        Debug.Log("Croucing");
        vcam1.m_Offset.y = 0.5f;
        //player.transform.position = new Vector3(this.transform.position.x, -0.7f, this.transform.position.z);
    }

    public void StandUp()
    {
        Debug.Log("Standed");
        vcam1.m_Offset.y = 1f;
    }
}
