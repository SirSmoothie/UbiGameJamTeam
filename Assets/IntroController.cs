using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject playerView;
    public GameObject dropPod;
    public bool playAnimation;
    public float fallingTime;

    public CinemachineImpulseSource impulseSourceSmallShake;
    public float smallShakeForce;
    public CinemachineImpulseSource impulseSourceBigLanding;
    public float bigLandingForce;
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
        CameraShakeManager.Current.UpdateGlobalShakeForce(smallShakeForce);
        CameraShakeManager.Current.CameraShake(impulseSourceSmallShake);
        dropPod.GetComponent<DropPodIntroController>().Falling();
        playerView.transform.position = startPos;
        dropPod.transform.position = startPos;
        playerView.transform.DOMove(new Vector3(0,-9.338753f,0), fallingTime).SetEase(Ease.Linear);
        dropPod.transform.DOMove(new Vector3(0,-9.338753f,0), fallingTime).SetEase(Ease.Linear);
        yield return new WaitForSeconds(fallingTime);
        dropPod.GetComponent<DropPodIntroController>().Landed();
        CameraShakeManager.Current.UpdateGlobalShakeForce(bigLandingForce);
        CameraShakeManager.Current.CameraShake(impulseSourceBigLanding);
        EventBus.Current.UpdateIntroBool(false);
    }
    
    public void OnDestroy()
    {
        
    }
}
