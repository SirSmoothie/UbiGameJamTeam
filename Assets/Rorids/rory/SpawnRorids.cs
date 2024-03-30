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

        public int indexForBoidToSpawn;
        public void SpawnSelected()
        {
            for (int x = 0; x < SpawnSize; x++)
            {
                for (int z = 0; z < SpawnSize; z++)
                {
                    var o = Instantiate(Boid[indexForBoidToSpawn], new Vector3(x, 0, z), Quaternion.identity);
                    o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform;   
                }
            }
        }
        
        public void SpawnOneOfEach()
        {
            for (int i = 0; i < Boid.Length; i++)
            {
                for (int x = 0; x < SpawnSize; x++)
                {
                    for (int z = 0; z < SpawnSize; z++)
                    {
                        var o = Instantiate(Boid[i], new Vector3(transform.position.x + x, 0, transform.position.z + z), Quaternion.identity);
                        o.GetComponent<RoridsTurnTowards>().targetTransform = targetObject.transform; 
                    }
                }
            }
        }
    }
}
