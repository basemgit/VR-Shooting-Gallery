using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Duration of the countdown in seconds
    public TextMeshProUGUI countdownText; // Reference to a UI Text element (optional)

    private float remainingTime;
    private bool isCountingDown = false;

    void Start()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        remainingTime = countdownTime;
        isCountingDown = true;
    }

    void Update()
    {
        if (isCountingDown)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime; // Reduce time based on frame time
                UpdateCountdownDisplay();
            }
            else
            {
                remainingTime = 0;
                isCountingDown = false;
                OnCountdownEnd();
            }
        }
    }

    private void UpdateCountdownDisplay()
    {
        // Format time in minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

       

        if (countdownText != null)
        {
            // Display the timer in the format MM:SS

            countdownText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void OnCountdownEnd()
    {
        Debug.Log("Countdown Complete!");
        // Add any actions you want to trigger at the end of the countdown.
        SceneManager.LoadScene("GameOver");
    }
}
