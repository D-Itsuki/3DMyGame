using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour
{
    [SerializeField] float jumpPower;
    public float ringCoolTime;
    float time;
    public GameObject ring;
    public GameObject ringGenerator;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.attachedRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > ringCoolTime)
        {
            Instantiate(ring, ringGenerator.transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
