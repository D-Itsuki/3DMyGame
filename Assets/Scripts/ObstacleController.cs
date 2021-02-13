using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject lookTarget;
    FPSController a;
    [SerializeField] Vector3 direction;
    [SerializeField] float dChangeTime;
    float dTimer;
    [SerializeField] bool lookAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lookAt)
        {
            this.transform.LookAt(lookTarget.transform);
        }
        this.transform.position += direction;
        dTimer += Time.deltaTime;
        if (dTimer > dChangeTime)
        {
            direction *= -1;
            dTimer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            a = collision.gameObject.GetComponent<FPSController>();
            a.Damage();
        }
    }
}
