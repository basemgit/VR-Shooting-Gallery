
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelName;
    // Start is called before the first frame update
    void Start()
    {
        SaveLevel();
        DisplayLevelName();
    }

    private void SaveLevel()
    {
        PlayerPrefs
            .SetInt("CurrentLevel",
            System.Convert.ToInt32(SceneManager.GetActiveScene().name));

    }

    private void DisplayLevelName()
    {
        levelName.text = "Level: " + SceneManager.GetActiveScene().name;

    }
}
