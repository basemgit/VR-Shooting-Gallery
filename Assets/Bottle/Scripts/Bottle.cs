using System;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] GameObject brokenBottlePrefab;
    public event Action OnBottleDestroyed; // Event triggered when this bottle is destroyed

    void Update() // just for testing
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Explode();
        }
    }

    public void Explode()
    {
        GameObject brokenBottle = Instantiate(brokenBottlePrefab, this.transform.position, Quaternion.identity);
        brokenBottle.GetComponent<BrokenBottle>().RandomVelocities();
        Destroy(gameObject);
    }


    void OnDestroy()
    {
        // Notify that this bottle is destroyed
        OnBottleDestroyed?.Invoke();
        Debug.Log("Bottle destroyed!");
    }
}
