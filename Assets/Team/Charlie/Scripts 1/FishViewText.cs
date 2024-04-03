using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishViewText : MonoBehaviour
{
    public class FishEvents : MonoBehaviour
    {

        public delegate void FishGeneratedEventHandler(string fishName);

        public static event FishGeneratedEventHandler OnFishGenerated;


        public static void FishGenerated(string fishName)
        {
            if (OnFishGenerated != null)
            {
                OnFishGenerated.Invoke(fishName);
            }
        }
    }
}
