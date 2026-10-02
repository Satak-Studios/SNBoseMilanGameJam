using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    public GameObject gameCompleteScreen = null;
    bool gameCompleted = false;
    public bool isBoss;

    public GameObject secondCam;

    public bool isFirstWave = true;
    public bool theEnd = false;
    public bool theThirdLevel = false;

    public int currentLevel = 1;

    public GameObject[] Waves;

    public Text currentLevelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (FindAnyObjectByType<Enemy>() == null && !isBoss)
        {
            GameComplete();
            gameCompleted = true;
        }
        else if(!isBoss && FindAnyObjectByType<Enemy>() != null)
        {
            gameCompleted = false;
        }

        if (isBoss && FindAnyObjectByType<Boss>() == null && FindAnyObjectByType<Enemy>() == null && FindAnyObjectByType<MiniBoss>() == null && theEnd)
        {
            Debug.Log("hey!");
            gameCompleted = true;
            GameComplete();
        }
        else if (isBoss && (FindAnyObjectByType<MiniBoss>() != null || FindAnyObjectByType<Enemy>() != null))
        {
            gameCompleted = false;
        }*/
        if (FindAnyObjectByType<Enemy>() == null)
        {
            GameComplete();
            gameCompleted = true;
        }
        else
        {
            string levelName = SceneManager.GetActiveScene().name;
            currentLevelText.text = levelName;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        secondCam.SetActive(true);
        if (FindAnyObjectByType<playerMovement>() != null)
        {
            Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        }
        GetComponent<MoneyManager>().timerRunning = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void GameComplete()
    {
        /*if (!isBoss)
        {*/
        levelCompleteScreen.SetActive(true);
        secondCam.SetActive(true);
        gameCompleted = true;
        if (!gameCompleted)
        {
            Destroy(FindAnyObjectByType<playerMovement>().gameObject);
        }
        GetComponent<MoneyManager>().timerRunning = false;
        PlayerPrefs.SetFloat("money", GetComponent<MoneyManager>().playerMoney);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        /*}
        else
        {
            gameCompleteScreen.SetActive(true);
            secondCam.SetActive(true);
            gameCompleted = true;
            if (!gameCompleted)
            {
                Destroy(FindAnyObjectByType<playerMovement>().gameObject);
            }
            Cursor.lockState = CursorLockMode.None;
        }*/
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level - 1");
    }
    
    public void NextLvl()
    {
        {
            SceneManager.LoadScene("Level - " + (SceneManager.GetActiveScene().buildIndex+1));
        }
    }

    public void MainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            PlayerPrefs.SetInt("YO", 1);
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void GameCompleted()
    {
        SceneManager.LoadScene("LevelManager");
    }
}
