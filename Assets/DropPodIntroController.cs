using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropPodIntroController : MonoBehaviour
{
    public GameObject dropPodBroken;
    public GameObject dropPodFixed;
    public ParticleSystem particles;
    public Vector3 LandedRotation;

    public void Landed()
    {
        dropPodBroken.SetActive(true);
        dropPodFixed.SetActive(false);
        particles.Play();
        dropPodBroken.transform.DORotate(LandedRotation, 2f).SetEase(Ease.InSine);
    }
    public void Falling()
    {
        dropPodBroken.SetActive(false);
        dropPodFixed.SetActive(true);
    }
}
