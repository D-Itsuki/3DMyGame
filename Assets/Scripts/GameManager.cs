using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int targets = 0;
    int clearCoins;
    bool clear = false;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject mainCamera = null;
    [SerializeField] GameObject clearTimeLine = null;
    [SerializeField] GameObject clearCamera = null;
    GameObject[] obstacles = null;

    // Start is called before the first frame update
    void Start()
    {
        clearCoins = GameObject.FindGameObjectsWithTag("coin").Length;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        //player = GameObject.FindGameObjectWithTag("Player");
        //mainCamera = GameObject.FindGameObjectWithTag("PlayerEye");
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
        foreach (var item in obstacles)
        {
            Destroy(item);
        }
        player.SetActive(false);
        mainCamera.SetActive(false);
        clearCamera.SetActive(true);
        clearTimeLine.SetActive(true);
    }
}
