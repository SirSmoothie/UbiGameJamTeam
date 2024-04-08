using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace rory
{
    public class SpawnRorids : MonoBehaviour
    {
        [SerializeField] private int spawnSizeX;
        [SerializeField] private int spawnSizeY;
        public int minAmountOfFish;
        public int maxAmountOfFish;
        
        public GameObject[] Boid;

        public GameObject targetObject;
        public List<GameObject> FamilyFishes = new List<GameObject>();
        public int indexForBoidToSpawn;

        private void Awake()
        {
            spawnSizeX = Random.Range(minAmountOfFish, maxAmountOfFish);
            spawnSizeY = Random.Range(minAmountOfFish, maxAmountOfFish);
            SpawnSelected();
        }


        public void SpawnSelected()
        {
            for (int x = 0; x < spawnSizeX; x++)
            {
                for (int z = 0; z < spawnSizeY; z++)
                {
                    var o = Instantiate(Boid[indexForBoidToSpawn], new Vector3(transform.position.x + x, transform.position.y + z, 0), quaternion.identity);
                    //FamilyFishes.Add();
                   // o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform;   
                }
            }
        }
        
        public void SpawnOneOfEach()
        {
            for (int i = 0; i < Boid.Length; i++)
            {
                for (int x = 0; x < spawnSizeX; x++)
                {
                    for (int y = 0; y < spawnSizeY; y++)
                    {
                        var o = Instantiate(Boid[i], new Vector3(transform.position.x + x, transform.position.y + y), Quaternion.identity);
                        //o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform; 
                    }
                }
            }
        }
    }
}
