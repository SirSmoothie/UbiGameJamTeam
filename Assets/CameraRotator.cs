using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Vector3 playerPos;
    public Vector3 minigameDir;
    public bool isPlaying;
    public MinigameController minigameController;

    private void Start()
    {
        minigameController.PlayingMinigameEvent += OneTickUpdate;
    }

    public void OneTickUpdate()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.transform.Rotate(minigameDir.x, minigameDir.y, minigameDir.z);
        }

        if (!isPlaying)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(playerPos.x, playerPos.y, playerPos.z);
        }
    }

    private void OnDestroy()
    {
        minigameController.PlayingMinigameEvent -= OneTickUpdate;
    }
}
