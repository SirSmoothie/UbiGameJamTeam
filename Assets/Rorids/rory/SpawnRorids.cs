using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{
    public class SpawnRorids : MonoBehaviour
    {
        public int SpawnSize;
        public GameObject[] Boid;

        public GameObject targetObject;
        public List<GameObject> FamilyFishes = new List<GameObject>();
        public int indexForBoidToSpawn;
        public void SpawnSelected()
        {
            for (int x = 0; x < SpawnSize; x++)
            {
                for (int z = 0; z < SpawnSize; z++)
                {
                    var o = Instantiate(Boid[indexForBoidToSpawn], new Vector3(transform.position.x + x, transform.position.y + z, 0), Quaternion.identity);
                    //FamilyFishes.Add();
                   // o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform;   
                }
            }
        }
        
        public void SpawnOneOfEach()
        {
            for (int i = 0; i < Boid.Length; i++)
            {
                for (int x = 0; x < SpawnSize; x++)
                {
                    for (int y = 0; y < SpawnSize; y++)
                    {
                        var o = Instantiate(Boid[i], new Vector3(transform.position.x + x, transform.position.y + y), Quaternion.identity);
                        //o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform; 
                    }
                }
            }
        }
    }
}
