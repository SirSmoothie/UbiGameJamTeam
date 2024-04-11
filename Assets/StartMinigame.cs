using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour, IInteractable
{
    public bool playingMinigame;
    public MinigameController minigame;
    public GameObject player;
    public void Interacted(GameObject Interactor)
    {
        if (!playingMinigame)
        {
            if(minigame.playedToday) return;
            if (minigame.amountOfFish <= 0) return;
            player.GetComponent<PlayerModel>().playerControlled = false;
            minigame.startTheGame();
            playingMinigame = true;
        }
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }
}
