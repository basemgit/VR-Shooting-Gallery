using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    private float minUpwardForce = 1f; // Adjust for throw height
    private float maxUpwardForce = 2f; // Adjust for throw height
    private float minForwardForce = 0.5f; // Optional forward movement
    private float maxForwardForce = 1f; // Optional forward movement
    public float minTime = 1f; // Minimum time between throws
    public float maxTime = 5f; // Maximum time between throws
    private float rotationForce = 1f; // Rotation speed (torque)
    public GameObject bonusBottle;
    private Rigidbody rb;
    private float minPosX = -6.35f;
    private float maxPosX = 1.58f;
    private float posY = -8.21f;
    private float posZ = 128.1f;
    void Start()
    {

        // Start the random throwing coroutine
        StartCoroutine(RandomThrowRoutine());
    }

    IEnumerator RandomThrowRoutine()
    {
        while (true) // Infinite loop for the level duration
        {
            float waitTime = Random.Range(minTime, maxTime); // Random interval
            yield return new WaitForSeconds(waitTime); // Wait for the random time
            float posX = Random.Range(minPosX, maxPosX);
            GameObject bottle = Instantiate(bonusBottle, new Vector3(posX, posY, posZ), Quaternion.identity);
            rb = bottle.GetComponent<Rigidbody>();
            Throw(rb); // Throw the object
        }
    }

    void Throw(Rigidbody rb)
    {
        if (rb != null)
        {
            // Reset velocity to avoid accumulated forces
            rb.velocity = Vector3.zero;

            // Apply an upward and forward force
            float upwardForce = Random.Range(minUpwardForce, maxUpwardForce);
            float forwardForce = Random.Range(minForwardForce, maxForwardForce);
            Vector3 force = new Vector3(0, upwardForce, -forwardForce);
            rb.AddForce(force, ForceMode.Impulse);

            // Apply random rotation (torque)
            Vector3 randomTorque = new Vector3(
                Random.Range(-rotationForce, rotationForce),
                0,
                0
            );
            rb.AddTorque(randomTorque, ForceMode.Impulse);

            Debug.Log($"Object thrown with force: {force} and torque: {randomTorque}");
        }
    }
}
