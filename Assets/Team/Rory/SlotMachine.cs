using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotMachine : MonoBehaviour, IInteractable
{
    public int slot1;
    public int slot2;
    public int slot3;

    public float timeTillSlotStops;
    public GameObject slotView1;
    public GameObject slotView2;
    public GameObject slotView3;

    public bool isSlotDone1;
    public bool slot1Stop;
    public bool isSlotDone2;
    public bool slot2Stop;
    public bool isSlotDone3;
    public bool slot3Stop;
    
    public int NumberOfSlotFaces;

    public float spinSpeed = 1f;

    public bool gameGoing;

    public int secondPrize, thirdPrize, forthPrize, fithPrize;
    
    public Animator anim;
    public void Update()
    {
        if (gameGoing)
        {
            if (!slot1Stop)
            {

                if (!isSlotDone1)
                {
                    slotView1.transform.Rotate(Time.deltaTime * spinSpeed, 0, 0);
                }
                else
                {
                    slotView1.transform.rotation = new Quaternion(0, 0, 0, 0);
                    slotView1.transform.Rotate( (slot1 * (360f / NumberOfSlotFaces)), 0, 0);
                    slot1Stop = true;
                }
            }

            if (!slot2Stop)
            {
                if (!isSlotDone2)
                {
                    slotView2.transform.Rotate(Time.deltaTime * spinSpeed, 0, 0);
                }
                else
                {
                    slotView2.transform.rotation = new Quaternion(0, 0, 0, 0);
                    slotView2.transform.Rotate( (slot2 * (360f / NumberOfSlotFaces)), 0, 0);
                    slot2Stop = true;
                }
            }

            if (!slot3Stop)
            {
                if (!isSlotDone3)
                {
                    slotView3.transform.Rotate(Time.deltaTime * spinSpeed, 0, 0);
                }
                else
                {
                    slotView3.transform.rotation = new Quaternion(0, 0, 0, 0);
                    slotView3.transform.Rotate( (slot3 * (360f / NumberOfSlotFaces)), 0, 0);
                    slot3Stop = true;
                }
            }
        }
    }
    
    
    private IEnumerator SlotCheckingThing()
    {
        yield return new WaitForSeconds(0.15f);
        isSlotDone1 = false;
        isSlotDone2 = false;
        isSlotDone3 = false;
        slot1Stop = false;
        slot2Stop = false;
        slot3Stop = false;
        yield return new WaitForSeconds(timeTillSlotStops);
        //StartCoroutine(SlotRotation(slotView1));
        isSlotDone1 = true;
        //var multi1 = slotView1.transform.localEulerAngles.z / 360;
        //var thing1 = multi1 - Mathf.FloorToInt(multi1);
        //var fixedRoation1 = 360 * multi1;
        //slotView1.transform.localEulerAngles = new Vector3(fixedRoation1, 0, 0);
        yield return new WaitForSeconds(timeTillSlotStops);
        //StartCoroutine(SlotRotation(slotView2));
        isSlotDone2 = true;
       //var multi2 = slotView2.transform.localEulerAngles.z / 360;
       //var thing2 = multi2 - Mathf.FloorToInt(multi2);
       //var fixedRoation2 = 360 * multi2;
       //slotView2.transform.localEulerAngles = new Vector3(fixedRoation2, 0, 0);
        yield return new WaitForSeconds(timeTillSlotStops);
        //StartCoroutine(SlotRotation(slotView3));
        isSlotDone3 = true;
        //var multi3 = slotView3.transform.localEulerAngles.z / 360;
        //var thing3 = multi3 - Mathf.FloorToInt(multi3);
        //var fixedRoation3 = 360 * multi3;
        //slotView3.transform.localEulerAngles = new Vector3(fixedRoation3, 0, 0);
        StartCoroutine(FinishedGame());
    }
    public void Interacted(GameObject Interactor)
    {
        var foodValue = PlayerInventory.Current.ReturnFishTotal();
        if (foodValue >= 1)
        {
            if (!gameGoing)
            {
                anim.SetTrigger("PlayAnimation");
                PlayerInventory.Current.changeFishAmountValue(-1);
                RandomizeSlots();
                StartCoroutine(SlotCheckingThing());
                gameGoing = true;
            }
        }
    }

    public void StopInteract()
    {
        throw new NotImplementedException();
    }

    public void RandomizeSlots()
    {
        slot1 = Random.Range(0, NumberOfSlotFaces-1);
        slot2 = Random.Range(0, NumberOfSlotFaces-1);
        slot3 = Random.Range(0, NumberOfSlotFaces-1);
    }

    IEnumerator FinishedGame()
    {
        CalulatePrize();
        anim.SetTrigger("GoBack");
        yield return new WaitForSeconds(1f);
        gameGoing = false;
    }

    public void CalulatePrize()
    {
        if (slot1 == 5 && slot2 == 5 && slot3 == 5)
        {
            var value = PlayerInventory.Current.ReturnFishTotal();
            PlayerInventory.Current.changeFishAmountValue(-value);
            return;
        }
        if (slot1 == 4 && slot2 == 4 && slot3 == 4)
        {
            PlayerInventory.Current.changeFishAmountValue(secondPrize);
            return;
        }
        if (slot1 == 4 && slot2 == 4 && slot3 == 5 || slot1 == 5 && slot2 == 4 && slot3 == 4 || slot1 == 4 && slot2 == 5 && slot3 == 4)
        {
            PlayerInventory.Current.changeFishAmountValue(thirdPrize);
            return;
        }

        if (slot1 >= 1 && slot1 <= 3)
        {
            if (slot2 >= 1 && slot2 <= 3)
            {
                if (slot3 >= 1 && slot3 <= 3)
                {
                    PlayerInventory.Current.changeFishAmountValue(forthPrize);
                    return;
                }
            }
        }
        if (slot1 == 0 || slot2 == 0 || slot3 == 0)
        {
            PlayerInventory.Current.changeFishAmountValue(fithPrize);
            return;
        }
    }
}
