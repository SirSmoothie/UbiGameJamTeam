using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStamp : MonoBehaviour

{
    public List<GameObject> chosenFish = new List<GameObject>();

    public void FindFish()
    {
        Fish[] fishes = FindObjectsOfType<Fish>(); 
        foreach (Fish fish in fishes)
        {
            StampFish(fish.gameObject);
        }
    }

    void StampFish(GameObject fishObject)
    {
        chosenFish.Clear();
        chosenFish.Add(fishObject);

        foreach (GameObject fish in chosenFish)
        {
            Fish fishComponent = fish.GetComponent<Fish>();
            if (fishComponent != null)
            {
   
                Debug.Log("Tail is poisoned: " + fishComponent.tail.isPoisoned);
                Debug.Log("Head is poisoned: " + fishComponent.head.isPoisoned);
                Debug.Log("Fin is poisoned: " + fishComponent.fin.isPoisoned);
            }

        }
    }
}



// {
//     public List<Fish> chosenFish = new List<Fish>();
//     public bool isRejectedHead = false;
//     public bool isRejectedTail = false;
//     public bool isRejectedFin = false;
//     public bool isRejected = false;
//
//     void FixedUpdate()
//     {
//         Fish[] fishes = FindObjectsOfType<Fish>(); // Find all GameObjects with Fish script attached
//         foreach (Fish fish in fishes)
//         {
//             StampFish(fish);
//         }
//     }
//
//     public void StampFish(Fish fish)
//     {
//         if (fish != null)
//         {
//             // Reset rejection status for each body part
//             isRejectedHead = false;
//             isRejectedTail = false;
//             isRejectedFin = false;
//
//             // Check if any of the body parts are poisoned
//             if (fish.tail != null && fish.tail.isPoisoned)
//             {
//                 Debug.Log("Fish rejected because tail is poisoned. Object: " + fish.gameObject.name);
//                 isRejectedTail = true;
//             }
//             if (fish.fin != null && fish.fin.isPoisoned)
//             {
//                 Debug.Log("Fish rejected because fin is poisoned. Object: " + fish.gameObject.name);
//                 isRejectedFin = true;
//             }
//             if (fish.head != null && fish.head.isPoisoned)
//             {
//                 Debug.Log("Fish rejected because head is poisoned. Object: " + fish.gameObject.name);
//                 isRejectedHead = true;
//             }
//
//             // Update the overall rejection status
//             isRejected = isRejectedHead || isRejectedTail || isRejectedFin;
//
//             // Player input to keep or throw away the fish
//             if (isRejected)
//             {
//                 Debug.Log("Press 'K' to keep or 'T' to throw away the fish.");
//                 if (Input.GetKeyDown(KeyCode.W))
//                 {
//                     Debug.Log("Fish kept.");
//                     isRejected = false;
//                 }
//                 else if (Input.GetKeyDown(KeyCode.Q))
//                 {
//                     Debug.Log("Fish thrown away.");
//                 }
//             }
//         }
//
//     }
// }