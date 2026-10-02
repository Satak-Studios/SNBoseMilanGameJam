using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text versionTxt;
    public GameObject gameCompleted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        versionTxt.text = "v"+Application.version;
        if (PlayerPrefs.GetInt("YO") == 1)
        {
            gameCompleted.SetActive(true);
        }
        else
        {
            gameCompleted.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level - 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
