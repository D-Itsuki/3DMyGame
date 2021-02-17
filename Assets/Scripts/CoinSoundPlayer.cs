using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundPlayer : MonoBehaviour
{
    float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > 1f)
        {
            Destroy(this.gameObject);
            //Debug.Log("a");
        }
    }
}
