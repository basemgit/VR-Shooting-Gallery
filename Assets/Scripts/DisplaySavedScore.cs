using TMPro;
using UnityEngine;

public class DisplaySavedScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text =
          "Your Score: " + PlayerPrefs.GetInt("Score", 0).ToString();

    }


}
