using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform rightFirePoint;
    public Transform leftFirePoint;
    public GameObject bulletPrefab; // Assign your bullet prefab in the Inspector
    public float bulletForce = 500f;
    public TextMeshProUGUI scoreText;
    private int score;
    public static GameManager Instance;
    public AudioSource gunSound;
    public AudioSource glassSound;
    public AudioSource bonusSound;
    public GameObject BonusText;
    private BottleManager bottleManager;
    public GameObject timer;


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
    private void Start()
    {
        if (PlayerPrefs.GetString("Mode", "").Equals("Endless"))
        {
            timer.SetActive(false);

        }

        if (PlayerPrefs.GetString("Mode", "").Equals("Timed"))
        {
            timer.SetActive(true);

        }


        score = PlayerPrefs.GetInt("Score", 0);
        CheckGameState();

    }

    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Right controller trigger
        {
            Shoot();
        }



        scoreText.text = "Score: " + score.ToString();
    }

    void Shoot()
    {
        // Instantiate the bullet
        GameObject rightBullet = Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);

        // Apply force to the bullet
        Rigidbody rightBulletRb = rightBullet.GetComponent<Rigidbody>();
        if (rightBulletRb != null)
        {
            rightBulletRb.AddForce(rightFirePoint.forward * bulletForce);
            gunSound.Play();
        }



    }


    public void IncreaseScore(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt("Score", score);
    }

    public void PlayGlassSound()
    {
        glassSound.Play();
    }

    public void PlayBonusSound()
    {
        bonusSound.Play();
    }

    public void ShowBonusText(GameObject hitObject)
    {

        GameObject bonusText = Instantiate(BonusText, hitObject.transform.position, Quaternion.identity);
        Destroy(bonusText.gameObject, 2);
    }

    private void CheckGameState()
    {
        bottleManager = FindObjectOfType<BottleManager>();
        if (bottleManager != null)
        {
            bottleManager.OnAllBottlesDestroyed += OnLevelComplete;
        }

    }

    private void OnLevelComplete()
    {
        Debug.Log("Level Complete! All bottles are destroyed.");
        if (timer.activeInHierarchy)
            timer.SetActive(false);
        StartCoroutine(Navigation.Instance.ToSceneDelay("LevelComplete", 2f));
    }


    private void OnDestroy()
    {
        if (bottleManager != null)
        {
            bottleManager.OnAllBottlesDestroyed -= OnLevelComplete;
        }
    }
}
