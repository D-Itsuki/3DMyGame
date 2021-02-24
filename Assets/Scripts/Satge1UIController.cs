using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Satge1UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leftCoins = null;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftCoins.text =GameManager.targets.ToString();
    }
}
