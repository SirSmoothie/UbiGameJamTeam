using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace rory
{
    [CustomEditor(typeof(SpawnRorids))]
    public class SpawnRoridsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Spawn One Type of Boids"))
            {
                (target as SpawnRorids)?.SpawnSelected();
            }
            
            if (GUILayout.Button("Spawn One of Each"))
            {
                (target as SpawnRorids)?.SpawnOneOfEach();
            }
        }
    }
}
