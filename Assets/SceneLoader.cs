using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    public int sceneToLoad;
    public int MainSceneIndex;
    public void Interacted(GameObject Player)
    {
        if (EventBus.Current.ReturnMainSceneBool())
        {
            EventBus.Current.UpdateMainSceneLocation(Player.transform.position);
        }
        if (MainSceneIndex == sceneToLoad)
        {
            EventBus.Current.UpdateMainSceneBool(true);
        }
        else
        {
            EventBus.Current.UpdateMainSceneBool(false);
        }
        
        //This must be last so the event bus can get the infomation before the scene loads, so everything in the next scene has the infomation it needs on awake.
        SceneManager.LoadScene(sceneToLoad);
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }
}
