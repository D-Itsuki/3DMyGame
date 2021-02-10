using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button m_firstbutton = null;

    // Start is called before the first frame update
    void Start()
    {
        m_firstbutton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
