using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampController : MonoBehaviour
{
    public bool greenStampSide;
    public bool equipedStamp;
    [SerializeField] private Vector3 GreenStampRestPosition;
    [SerializeField] private Vector3 RedStampRestPosition;
    [SerializeField] private GameObject greenStamp;
    [SerializeField] private GameObject redStamp;
    
    public void UseGreenStamp()
    {
        if (greenStampSide && equipedStamp)
        {
            ReturnStampsToRestPostion();
            equipedStamp = false;
            return;
        }
        ReturnStampsToRestPostion();
        equipedStamp = true;
        greenStampSide = true;
    }

    public void UseRedStamp()
    {
        if (!greenStampSide && equipedStamp)
        {
            ReturnStampsToRestPostion();
            equipedStamp = false;
            return;
        }
        ReturnStampsToRestPostion();
        equipedStamp = true;
        greenStampSide = false;
    }

    private void Update()
    {
        if (equipedStamp)
        {
            
            if (greenStampSide)
            {
                greenStamp.transform.position = Input.mousePosition;
            }
            else
            {
                redStamp.transform.position = Input.mousePosition;
            }
        }
    }

    public void ReturnStampsToRestPostion()
    {
        greenStamp.transform.localPosition = GreenStampRestPosition;
        redStamp.transform.localPosition = RedStampRestPosition;
    }
}
