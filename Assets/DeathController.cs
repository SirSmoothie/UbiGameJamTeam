using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        StartCoroutine(Animation());
        Destroy(EventBus.Current);
        Destroy(PlayerInventory.Current);
        Destroy(TimeManager.Current);
    }

    IEnumerator Animation()
    {
        text.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2f);
        text.GetComponent<CanvasGroup>().DOFade(0, 1).SetEase(Ease.Linear);
        SceneManager.LoadScene(0);
    }
}
