using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawner))]
public class SpawnEditor : Editor
{
    public override void OnInspectorGUI()
    {
    

        if (GUILayout.Button("Spawn"))
        {
           
            Spawner spawnEditor;
            spawnEditor = target as Spawner;
            if(spawnEditor != null)
            {
                spawnEditor .SpawnObject();
            }
        }
    }
}

