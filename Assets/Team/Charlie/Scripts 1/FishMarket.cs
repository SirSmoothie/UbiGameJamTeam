using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class FishMarket : MonoBehaviour
{
    public CardStamp cardStamp; 
    
    public List<Fish> fishList = new List<Fish>();

    public List<Fish> fishMarket = new List<Fish>();

    void Start()
    {
        
        Fish[] foundFish = GameObject.FindObjectsOfType<Fish>();
        foreach (Fish fish in foundFish)
        {
            fishList.Add(fish);
        }
    }
    public void GenerateFish()
    {
        int numberOfFish = Random.Range(1, 11);


        foreach (Fish generatedFish in fishMarket)
        {
            Destroy(generatedFish.gameObject);
        }
        fishMarket.Clear();

        for (int i = 0; i < numberOfFish; i++)
        {
            int randomIndex = Random.Range(0, fishList.Count);
            Fish fishPrefab = fishList[randomIndex];
            Fish newFish = Instantiate(fishPrefab);
            if (newFish != null)
            {
                fishMarket.Add(newFish);
                newFish.gameObject.SetActive(false);
            }
        }

        if (fishMarket.Count > 0)
        {
            fishMarket[0].gameObject.SetActive(true);
        }

        cardStamp.FindFish(); 
        
        
        

    }
}