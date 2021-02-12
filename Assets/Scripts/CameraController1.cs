using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController1 : MonoBehaviour
{
    [SerializeField] GameObject player;
    //Animator m_anim;
    //[SerializeField] CinemachineVirtualCamera vcam;

    private void Start()
    {
        player.GetComponent<Transform>();
        //m_anim = GetComponent<Animator>();
    }

    public void CrouchCamera()
    {
        Debug.Log("Croucing");
        player.transform.position = new Vector3(this.transform.position.x, -0.7f, this.transform.position.z);
        //vcam = 0.7f;
        //m_anim.SetBool("Crouch",true);
    }
}
