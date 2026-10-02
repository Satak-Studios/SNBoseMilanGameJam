using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    public float playerMoney=0;
    public float maxTime = 90;
    public float timeRemaining;
    public int baseReward;
    public int rewardFactor;
    //public int maxReward;
    public float currentReward;
    public bool timerRunning = false;

    //Thy UI hath Arrived(Maine AI ka upyog nhi kiya :D)
    public Slider timeSlider;
    public Text timeRemainingText;
    public Text moneyText;

    int a = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetFloat("money", 0);
            playerMoney = 0;
        }
        else
        {
            playerMoney = PlayerPrefs.GetFloat("money");
        }
        timeRemaining = maxTime;
        timeSlider.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning && !(timeRemaining < 0))
        {
            timeRemaining -= (Time.deltaTime);
            timeRemainingText.text = "⏱"+timeRemaining.ToString("00");
            timeSlider.value = timeRemaining;
        }
        else
        {
            timerRunning = false;
            GetComponent<GameManager>().GameOver();
        }

        moneyText.text = "Money : $" + Mathf.FloorToInt(playerMoney).ToString();
        DecayReward();
    }

    void DecayReward()
    {
        /*if (timeRemaining >= (maxTime * 0.9))
        {
            currentReward = maxReward;
        }
        else if (timeRemaining >= (maxTime * 0.8))
        {
            if ((maxReward * 0.8) >= baseReward)
                currentReward = (int)(0.8 * maxReward);
        }
        else if (timeRemaining >= (maxTime * 0.7))
        {
            if ((maxReward * 0.6) >= baseReward)
                currentReward = (int)(0.6 * maxReward);
        }
        else if (timeRemaining >= (maxTime * 0.6))
        {
            if ((maxReward * 0.4) >= baseReward)
                currentReward = (int)(0.4 * maxReward);
        }
        else if (timeRemaining >= (maxTime * 0.5))
        {
            if ((maxReward * 0.2) >= baseReward)
                currentReward = (int)(0.2 * maxReward);
        }
        else
        {
            currentReward = baseReward;
        }*/

        //float timePassed = maxTime - timeRemaining;
        if (timerRunning)
        {
            float ratioTime = ((timeRemaining) / maxTime);
            float a = ratioTime * ratioTime;
            currentReward = baseReward + ((a * a) * rewardFactor);
        }
        else
        {
            if (a == 0)
            {
                playerMoney = PlayerPrefs.GetFloat("money") + currentReward;
                a++;
            }    
        }
    }
}
