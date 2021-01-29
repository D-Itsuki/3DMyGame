using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    GameManager GameManager;
    public GameObject sound;
    int clearCoins;

    // Start is called before the first frame update
    void Start()
    {
        clearCoins = GameObject.FindGameObjectsWithTag("coin").Length - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinGet();
        if (GameManager.targets > clearCoins)
        {
            Clear();
        }
        Instantiate(sound, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1.0f));
    }
    public void CoinGet()
    {
        GameManager.targets += 1;
        Debug.Log(GameManager.targets);
    }

    public void Clear()
    {
        Debug.Log("clear");
    }

}
