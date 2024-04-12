using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public class Tail
{
    public string nameOfBodyPart;
    public bool isPoisoned;
    public int imageNumber;
    public GameObject tailObject;
    
    public Tail(string name, bool poisoned, int image)
    {
        nameOfBodyPart = name;
        isPoisoned = poisoned;
        imageNumber = image;
    }
}
[Serializable]
public class Head
{
    public string nameOfBodyPart;
    public bool isPoisoned;
    public int imageNumber;
    public GameObject headObject;
    public Head(string name, bool poisoned, int image)
    {
        nameOfBodyPart = name;
        isPoisoned = poisoned;
        imageNumber = image;
    }
}
[Serializable]
public class Body
{
    public string nameOfBodyPart;
    public bool isPoisoned;
    public int imageNumber;
    public GameObject bodyObject;
    
    public Body(string name, bool poisoned, int image)
    {
        nameOfBodyPart = name;
        isPoisoned = poisoned;
        imageNumber = image;
    }
    
}

public class Fish : MonoBehaviour
{
    public List<Head> headList;
    public List<Body> bodyList;
    public List<Tail> tailList;
    
    public Head head;
    public Body body;
    public Tail tail;
    
    public float TailPoisonRate = 0.5f; // needs to be changed if u want, idk
    public float FinPoisonRate = 0.5f;// needs to be changed if u want, idk
    public float HeadPoisonRate = 0.5f;// needs to be changed if u want, idk

    public int min = 1;
    public int max = 10;
    void Start()
    {
        // string[] possibleTailNames = { "Regular Tail", "Long Tail", "Curly Tail" };// these r placeholder names rory can think of wot goes here
        // string randomTailName = possibleTailNames[UnityEngine.Random.Range(0, possibleTailNames.Length)];
        //
        // string[] possibleHeadNames = { "Big Head", "Small Head", "Round Head" }; // these r placeholder names rory can think of wot goes here
        // string randomHeadName = possibleHeadNames[UnityEngine.Random.Range(0, possibleTailNames.Length)];
        //
        // string[] possibleFinNames = { "Small Fin", "Large Fin", "Sharp Fin" };// these r placeholder names rory can think of wot goes here
        // string randomfinName = possibleFinNames[UnityEngine.Random.Range(0, possibleTailNames.Length)];

        head = headList[Random.Range(0, headList.Count)];
        body = bodyList[Random.Range(0, bodyList.Count)];
        tail = tailList[Random.Range(0, tailList.Count)];
        
        head.headObject.SetActive(true);
        body.bodyObject.SetActive(true);
        tail.tailObject.SetActive(true);
        // Example usage:
        // tail = new Tail(randomTailName, UnityEngine.Random.value < TailPoisonRate, UnityEngine.Random.Range(min, max));
        // body = new Body(randomHeadName, UnityEngine.Random.value < FinPoisonRate, UnityEngine.Random.Range(min, max));
        // head = new Head(randomfinName, UnityEngine.Random.value < HeadPoisonRate, UnityEngine.Random.Range(min, max));
        
    }
    
    
    
    
    
    
}
