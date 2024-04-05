using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


[Serializable]
public class tTail
{
    public string nameOfBodyPart;
    public bool isPoisoned;
    public int imageNumber;
    
    public tTail(string name, bool poisoned, int image)
    {
        nameOfBodyPart = name;
        isPoisoned = poisoned;
        imageNumber = image;
    }
}
[Serializable]
public class tHead
{
    public string nameOfBodyPart;
    public bool isPoisoned;
    public int imageNumber;
    
    public tHead(string name, bool poisoned, int image)
    {
        nameOfBodyPart = name;
        isPoisoned = poisoned;
        imageNumber = image;
    }
}
[Serializable]
public class tFin
{
    public string nameOfBodyPart;
    public bool isPoisoned;
    public int imageNumber;
    
    public tFin(string name, bool poisoned, int image)
    {
        nameOfBodyPart = name;
        isPoisoned = poisoned;
        imageNumber = image;
    }
    
}
public class Fish : MonoBehaviour
{
    public tTail tail;
    public tFin fin;
    public tHead head;
    
    public float TailPoisonRate = 0.5f; // needs to be changed if u want, idk
    public float FinPoisonRate = 0.5f;// needs to be changed if u want, idk
    public float HeadPoisonRate = 0.5f;// needs to be changed if u want, idk

    public int min = 1;
    public int max = 10;
    void Start()
    {
        string[] possibleTailNames = { "Regular Tail", "Long Tail", "Curly Tail" };// these r placeholder names rory can think of wot goes here
        string randomTailName = possibleTailNames[UnityEngine.Random.Range(0, possibleTailNames.Length)];
        
        string[] possibleHeadNames = { "Big Head", "Small Head", "Round Head" }; // these r placeholder names rory can think of wot goes here
        string randomHeadName = possibleHeadNames[UnityEngine.Random.Range(0, possibleTailNames.Length)];
        
        string[] possibleFinNames = { "Small Fin", "Large Fin", "Sharp Fin" };// these r placeholder names rory can think of wot goes here
        string randomfinName = possibleFinNames[UnityEngine.Random.Range(0, possibleTailNames.Length)];
        
        
        // Example usage:
        tail = new tTail(randomTailName, UnityEngine.Random.value < TailPoisonRate, UnityEngine.Random.Range(min, max));
        fin = new tFin(randomHeadName, UnityEngine.Random.value < FinPoisonRate, UnityEngine.Random.Range(min, max));
        head = new tHead(randomfinName, UnityEngine.Random.value < HeadPoisonRate, UnityEngine.Random.Range(min, max));
        
    }
    
    
    
    
    
    
}
