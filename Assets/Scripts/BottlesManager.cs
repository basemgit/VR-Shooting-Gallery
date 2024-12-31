using System;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    public event Action OnAllBottlesDestroyed; // Event triggered when all bottles are destroyed

    private int bottleCount; // Number of bottles remaining

    void Start()
    {
        // Find all bottle objects in the scene and initialize bottle count
        GameObject[] bottles = GameObject.FindGameObjectsWithTag("Bottle");
        bottleCount = bottles.Length;

        // Subscribe to the BottleDestroyed event in each Bottle
        foreach (GameObject bottle in bottles)
        {
            Bottle bottleScript = bottle.GetComponent<Bottle>();
            if (bottleScript != null)
            {
                bottleScript.OnBottleDestroyed += BottleDestroyed; // Subscribe to the event
            }
        }
    }

    // Method to be called when a bottle is destroyed
    private void BottleDestroyed()
    {
        bottleCount--;
        Debug.Log($"Bottle destroyed! {bottleCount} bottles remaining.");

        // Check if all bottles are destroyed
        if (bottleCount <= 0)
        {
            // Trigger the OnAllBottlesDestroyed event when all bottles are destroyed
            OnAllBottlesDestroyed?.Invoke();
        }
    }


    private void OnDestroy()
    {
        // Unsubscribe from the BottleDestroyed event
        GameObject[] bottles = GameObject.FindGameObjectsWithTag("Bottle");
        foreach (GameObject bottle in bottles)
        {
            Bottle bottleScript = bottle.GetComponent<Bottle>();
            if (bottleScript != null)
            {
                bottleScript.OnBottleDestroyed -= BottleDestroyed; // Unsubscribe from the event
            }
        }
    }
}
