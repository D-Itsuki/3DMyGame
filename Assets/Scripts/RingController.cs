using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    float time;
    public float deathTime;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.01f, 0);
        time += Time.deltaTime;
        if (time > deathTime)
        {
            Destroy(this.gameObject);
        }
    }
}
