using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button myButton1; // Reference to the button
    public Button myButton3; // Reference to the button

    void Start()
    {
        // Option 1: Assign via Inspector (if using public variable)
        if (myButton1 != null)
        {
            myButton1.onClick.AddListener(OnButton1Click);
            myButton3.onClick.AddListener(OnButton3Click);
        }
    }

    // Function called when the button is clicked
    void OnButton1Click()
    {
        Debug.Log("Button clicked!");
        // Add your custom logic here
        Navigation.Instance.ToScene("1");
    }


    void OnButton3Click()
    {
        Debug.Log("Button clicked!");
        // Add your custom logic here
        Navigation.Instance.ToScene("3");
    }
}
