using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace rory
{
    [CustomEditor(typeof(BetterBoidAvoid))]
    public class BetterBoidAvoidEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Spawn One Type of Boids"))
            {
                (target as BetterBoidAvoid)?.CalculateNewThing();
            }
        }
    }
}