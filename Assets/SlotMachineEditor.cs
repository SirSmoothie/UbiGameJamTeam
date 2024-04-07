using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SlotMachine))]
public class SlotMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("USE GAMBLING ADICTION"))
        {
            SlotMachine slotMachineEditor;
            slotMachineEditor = target as SlotMachine;
            if(slotMachineEditor != null)
            {
                slotMachineEditor.Interacted(null);
            }
        }
    }
}
