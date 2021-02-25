using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] GameObject fadePanelPrefub;
    [SerializeField] GameObject canvas;
    [SerializeField] string nextScene;
    [SerializeField] string gameOverScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load(int a)
    {
        if (a == 1)
        {
            StartCoroutine(LoadStart(nextScene));
        }
        else
        {
            StartCoroutine(LoadStart(gameOverScene));
        }
    }

    IEnumerator LoadStart(string nextStage)
    {
        Instantiate(fadePanelPrefub, canvas.transform);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextStage);
    }
}
