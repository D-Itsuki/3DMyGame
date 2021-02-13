using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour
{
    [SerializeField] Transform[] targets;
    [SerializeField] float sDis;
    int tNum = 0;
    [SerializeField] float speed;
    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targets[tNum]);
        if (sDis < Vector3.Distance(this.transform.position, targets[tNum].position))
        {
            Vector3 dir = transform.forward;
            Vector3 velo = dir.normalized * speed;
            m_rb.velocity = velo;
        }
        else
        {
            tNum += 1;
        }
        if (tNum == targets.Length)
        {
            tNum = 0;
        }
    }
}
