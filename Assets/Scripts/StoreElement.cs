using UnityEngine;

public class StoreElement : MonoBehaviour
{
    public GameObject tutuOne;
    public GameObject tutuTwo;
    public GameObject tutuThree;

    public bool isTutu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isTutu)
        {
            PlayerPrefs.DeleteKey("a");
        }
        if (!PlayerPrefs.HasKey("a"))
        {
            tutuOne.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            tutuOne.SetActive(false);
            tutuTwo.SetActive(false);
            tutuThree.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerPrefs.HasKey("a"))
        {
            //tutuOne.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CloseTutuOne()
    {
        tutuOne.SetActive(false);
        tutuTwo.SetActive(true);
        tutuThree.SetActive(false);
    }
    
    public void CloseTutuTwo()
    {
        tutuOne.SetActive(false);
        tutuTwo.SetActive(false);
        tutuThree.SetActive(true);
    }

    public void Close()
    {
        tutuThree.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("a", 1);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
