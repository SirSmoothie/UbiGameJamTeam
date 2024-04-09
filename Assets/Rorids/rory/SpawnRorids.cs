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
        
        public GameObject[] commonFish;
        public GameObject[] uncommonFish;
        public GameObject[] rareFish;
        public GameObject[] legendaryFish;

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
                    var chance = Random.Range(0, 9);
                    if (chance <= 5)
                    {
                        var newIndexCommonFish = Random.Range(0, commonFish.Length);
                        var oCommonFish = Instantiate(commonFish[newIndexCommonFish], new Vector3(transform.position.x + x, transform.position.y + z, 0), quaternion.identity);   
                    }
                    else if (chance >= 8)
                    {
                        var newIndexRareFish = Random.Range(0, rareFish.Length);
                        var o = Instantiate(rareFish[newIndexRareFish], new Vector3(transform.position.x + x, transform.position.y + z, 0), quaternion.identity);
                    }
                    else
                    {
                        var newIndexUncommonFish = Random.Range(0, uncommonFish.Length);
                        var oUncommonFish = Instantiate(uncommonFish[newIndexUncommonFish], new Vector3(transform.position.x + x, transform.position.y + z, 0), quaternion.identity);
                    }
                    //FamilyFishes.Add();
                   // o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform;   
                }
            }
            var newIndexLegendaryFish = Random.Range(0, legendaryFish.Length);
            var oLegendaryFish = Instantiate(legendaryFish[newIndexLegendaryFish], new Vector3(transform.position.x, transform.position.y, 0), quaternion.identity);
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
