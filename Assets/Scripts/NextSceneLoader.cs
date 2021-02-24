using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneLoader : LoadSceneManager
{

    private void OnEnable()
    {
        Load(1);
    }
}
