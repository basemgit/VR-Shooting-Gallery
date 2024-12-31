using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > currentLevel)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
