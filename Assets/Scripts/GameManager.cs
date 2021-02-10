using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int targets = 0;
    int clearCoins;
    bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        clearCoins = GameObject.FindGameObjectsWithTag("coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (targets == clearCoins)
        {
            clear = true;
            GameClear();
            targets++;
        }
    }

    public void GameClear()
    {
        Debug.Log("GAME CLEAR!");
    }
}
