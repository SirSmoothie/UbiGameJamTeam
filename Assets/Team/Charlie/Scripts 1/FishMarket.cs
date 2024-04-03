using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class FishMarket : MonoBehaviour
{
    public GameObject[] availableFishPrefabs;

    
    public List<GameObject> keptFish = new List<GameObject>();
    public List<GameObject> discardedFish = new List<GameObject>();
    
    // TextMeshPro components to display lists
    public TMP_Text keptFishText;
    public TMP_Text discardedFishText;
    
    
    void Start()
    {
        GameObject fishPrefabContainer = GameObject.Find("FishStorage");
        if (fishPrefabContainer != null)
        {
            availableFishPrefabs = new GameObject[fishPrefabContainer.transform.childCount];
            for (int i = 0; i < fishPrefabContainer.transform.childCount; i++)
            {
                availableFishPrefabs[i] = fishPrefabContainer.transform.GetChild(i).gameObject;
            }
        }
    }
    
    void Update()
    {
        GameObject[] RemoveFromArray(GameObject[] array, GameObject item)
        {
            List<GameObject> tempList = new List<GameObject>(array);
            tempList.Remove(item);
            return tempList.ToArray();
        }
    }
    
    
    public void GenerateRandomFish()
    {
        if (availableFishPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, availableFishPrefabs.Length);

            GameObject randomFish = availableFishPrefabs[randomIndex];
            string fishName = randomFish.name;
            
            randomFish.SetActive(true);
            Debug.Log("Generated fish: " + fishName);
            
            // Invoke the fish generation event
            FishViewText.FishEvents.FishGenerated(fishName);
        }
    }
    


    private GameObject[] RemoveFromArray(GameObject[] gameObjects, GameObject fishPrefab)
    {
        List<GameObject> tempList = new List<GameObject>(gameObjects);
        tempList.Remove(fishPrefab);
        return tempList.ToArray();
    }
}
