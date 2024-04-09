using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    private static EventBus _current;
    public static EventBus Current { get { return _current; } }
    private void Awake()
    {
        if (_current != null && _current != this)
        {
            Destroy(this.gameObject);
        } else {
            _current = this;
            DontDestroyOnLoad(gameObject);
        } 
    }
    
    [SerializeField] private int foodValue;
    [SerializeField] private int fishCaught;

    [SerializeField] private Vector3 LocationInMainScene;
    [SerializeField] private bool inMainScene;

    [SerializeField] private bool playerInteractOn;
    [SerializeField] private bool playerPlayerControlOn;
    [SerializeField] private bool inWater;
    [SerializeField] private GameObject playerGameObject;

    public void ChangeInWaterBool(bool value)
    {
        inWater = value;
    }
    public bool ReturnInWaterBool()
    {
        return inWater;
    }

    public void UpdateMainSceneLocation(Vector3 loc)
    {
        LocationInMainScene = loc;
    }
    public Vector3 ReturnOldLocation()
    {
        return LocationInMainScene;
    }

    public void UpdateMainSceneBool(bool value)
    {
        inMainScene = value;
    }
    public bool ReturnMainSceneBool()
    {
        return inMainScene;
    }

    public void ChangeInteracting(bool value)
    {
        playerInteractOn = value;
    }
    public bool ReturnInteracting()
    {
        return playerInteractOn;
    }
    public void ChangePlayerControl(bool value)
    {
        playerPlayerControlOn = value;
    }
    public bool ReturnPlayerControl()
    {
        return playerPlayerControlOn;
    }

    public void IAmThePlayer(GameObject playerObject)
    {
        //Debug.Log("Player Set In Game Manager");
        playerGameObject = playerObject;
        //Debug.Log(playerObject.transform);
        //Debug.Log(playerGameObject.transform);
        UpdatePlayerObject();

    }
    public GameObject PlayerReference()
    {
        //Debug.Log("returned from Game Manager");
        //Debug.Log(playerGameObject);
        return playerGameObject;
    }
    public delegate void UpdatePlayerGameObject();
    public event UpdatePlayerGameObject UpdatePlayerGameObjectEvent;
    public void UpdatePlayerObject()
    {
        //Debug.Log("CallingEvent");
        UpdatePlayerGameObjectEvent?.Invoke();
    }
}
