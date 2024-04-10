using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject playerView;
    public bool playAnimation;
    public float fallingTime;
    
    
    private void Awake()
    {
    }

    private void Start()
    {
        FindIntroBool();
        if (playAnimation)
        {
            StartCoroutine(IntroAnimation());
        }
    }

    public void FindIntroBool()
    {
        var value = EventBus.Current.ReturnIntroBool();
        playAnimation = value;
    }

    IEnumerator IntroAnimation()
    {
        playerView.transform.position = startPos;
        playerView.transform.DOMove(new Vector3(0,-9.338753f,0), fallingTime).SetEase(Ease.Linear);
        yield return new WaitForSeconds(fallingTime);
        
        EventBus.Current.UpdateIntroBool(false);
    }
    
    public void OnDestroy()
    {
        
    }
}
