using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public static Navigation Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

            Destroy(gameObject);
        }
    }

    public void Restart()
    {

        SceneManager
            .LoadScene((PlayerPrefs.GetInt("CurrentLevel", 1).ToString()));
    }


    public void ToScene(string scene)
    {
        {
            SceneManager.LoadScene(scene);
        }
    }


    public IEnumerator ToSceneDelay(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(scene);
    }


    public void ToNextLevel()
    {
        if (PlayerPrefs.GetInt("CurrentLevel", 1) == 3)
        {
            ToScene("MainMenu");
        }
        else
        {
            SceneManager
            .LoadScene((PlayerPrefs.GetInt("CurrentLevel", 1) + 1).ToString());
        }


    }

    public void TimedMode()
    {
        PlayerPrefs.SetString("Mode", "Timed");
        ToScene("LevelSelect");
    }

    public void EndlessMode()
    {
        PlayerPrefs.SetString("Mode", "Endless");
        ToScene("LevelSelect");
    }

}
