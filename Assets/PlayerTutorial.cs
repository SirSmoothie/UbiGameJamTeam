using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    public GameObject player;
    public bool isCapsuleCollider;
    public bool isInteractCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            if (isCapsuleCollider)
            {
                SwitchToPlayerControlledLimited();
            }

            if (isInteractCollider)
            {
                SwitchToPlayerControlledFull();
            }
        }
    }

    public void SwitchToPlayerControlledLimited()
    {
        player.GetComponent<PlayerModel>().PlayerControlledLimited(true);
        EventBus.Current.ChangePlayerControl(true);
    }

    public void SwitchToPlayerControlledFull()
    {
        player.GetComponent<PlayerModel>().PlayerControlled(true);
        EventBus.Current.ChangeInteracting(true);
    }
}
