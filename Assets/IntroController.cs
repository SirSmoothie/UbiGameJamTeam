using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject playerView;
    public GameObject dropPod;
    public GameObject CameraTarget;
    public bool playAnimation;
    public float fallingTime;
    public GameObject ndview;
    public CinemachineImpulseSource impulseSourceSmallShake;
    public float smallShakeForce;
    public CinemachineImpulseSource impulseSourceBigLanding;
    public float bigLandingForce;

    public FootStepAudio Asource;

    public GameObject Daynighttext;
    private void Awake()
    {
    }

    private void Start()
    {
        Daynighttext.GetComponent<CanvasGroup>().alpha = 0;
        Asource = GetComponent<FootStepAudio>();
        FindIntroBool();
        if (playAnimation)
        {
            ndview.SetActive(false);
            playerView.SetActive(true);
            gameObject.GetComponent<PlayerModel>().playerControlled = false;
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
        //14.11442f+5f
        Asource.PlayFall();
        CameraShakeManager.Current.UpdateGlobalShakeForce(smallShakeForce);
        CameraShakeManager.Current.CameraShake(impulseSourceSmallShake);
        dropPod.GetComponent<DropPodIntroController>().Falling();
        playerView.transform.position = startPos;
        dropPod.transform.position = startPos;
        CameraTarget.transform.position = startPos;
        playerView.transform.DOMove(new Vector3(0,-9.338753f,0), fallingTime).SetEase(Ease.Linear);
        CameraTarget.transform.DOMove(new Vector3(0,-9.338753f,0), fallingTime).SetEase(Ease.Linear);
        dropPod.transform.DOMove(new Vector3(0,-9.338753f,0), fallingTime).SetEase(Ease.Linear);
        yield return new WaitForSeconds(fallingTime);
        CameraTarget.transform.position = new Vector3(0, 14.11442f + 5f, 0);
        Asource.PlayCrash();
        playerView.SetActive(false);
        ndview.SetActive(true);
        Daynighttext.GetComponent<CanvasGroup>().DOFade(1, 1).SetEase(Ease.Linear);
        dropPod.GetComponent<DropPodIntroController>().Landed();
        CameraShakeManager.Current.UpdateGlobalShakeForce(bigLandingForce);
        CameraShakeManager.Current.CameraShake(impulseSourceBigLanding);
        EventBus.Current.UpdateIntroBool(false);
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<PlayerModel>().playerControlled = true;
        EventBus.Current.ChangePlayerControl(true);
    }
    
    public void OnDestroy()
    {
        
    }
}
