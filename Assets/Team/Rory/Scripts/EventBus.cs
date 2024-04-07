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

    public void ChangeFoodCaughtAmount(int value)
    {
        fishCaught += value;
    }
}
