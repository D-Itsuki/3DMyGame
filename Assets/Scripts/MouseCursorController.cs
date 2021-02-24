using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    float time;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 1.0f;
        if (time > 2)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
