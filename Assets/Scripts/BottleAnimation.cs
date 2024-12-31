using UnityEngine;

public class BottleAnimation : MonoBehaviour
{
    private float minY = -10f; // Minimum Y value
    private float maxY; // Maximum Y value
    public float speed = 2f; // Speed of the animation

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        maxY = initialPosition.y;
    }

    void Update()
    {
        // Calculate a PingPong value between minY and maxY
        float pingPongValue = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;

        // Update the Y position while keeping X and Z constant
        transform.position = new Vector3(initialPosition.x, pingPongValue, initialPosition.z);
    }
}
