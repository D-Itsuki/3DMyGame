using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int targets = 0;
    int remaningCoin;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject mainCamera = null;
    [SerializeField] GameObject clearTimeLine = null;
    [SerializeField] GameObject clearCamera = null;
    GameObject[] obstacles = null;
    LoadSceneManager loader;
    public static bool m_isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        remaningCoin = GameObject.FindGameObjectsWithTag("coin").Length;
        targets = remaningCoin;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        loader = GetComponent<LoadSceneManager>();
        m_isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (targets == 0)
        {
            targets = 0;
            loader.Load(1);
        }
        if (m_isGameOver)
        {
            m_isGameOver = false;
            loader.Load(2);
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
