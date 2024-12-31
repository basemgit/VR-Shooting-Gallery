using UnityEngine;
using UnityEngine.UI;

public class ModeSelectionHandler : MonoBehaviour
{
    public Button EndlessModeButton; // Reference to the button


    void Start()
    {
        // Option 1: Assign via Inspector (if using public variable)
        if (EndlessModeButton != null)
        {
            EndlessModeButton.onClick.AddListener(OnButton1Click);
        }
    }

    // Function called when the button is clicked
    void OnButton1Click()
    {
        Debug.Log("Button clicked!");
        // Add your custom logic here
        Navigation.Instance.EndlessMode();
    }


    void OnButton3Click()
    {
        Debug.Log("Button clicked!");
        // Add your custom logic here
        Navigation.Instance.ToScene("3");
    }
}
