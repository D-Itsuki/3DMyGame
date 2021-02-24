using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeController : MonoBehaviour
{
    Image fadePanelImage;
    [SerializeField] float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        fadePanelImage = GetComponent<Image>();
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fade()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(fadePanelImage.DOFade(1, fadeTime));
        seq.Play();
    }
}
