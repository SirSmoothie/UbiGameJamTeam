using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InspectObject))]
public class InspectObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("DisplayText"))
        {
            InspectObject inspectObject;
            inspectObject = target as InspectObject;
            if(inspectObject != null)
            {
                //inspectObject.DisplayDescription();
            }
        }
    }
}
