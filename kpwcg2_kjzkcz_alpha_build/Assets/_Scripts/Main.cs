using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;

    public GameObject BeeFab;
    public GameObject spawnButton;
    public GameObject sp;

    public Text remainingLivesTxt;
    public Text levelText;

    public int numLives;
    public int numBall;
    int level;

    public Text timeText;
    public float timeRemaining = 240;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    private void Awake()
    {
        //GameObject Bee =Instantiate<GameObject>(BeeFab);
        //Bee.transform.position = this.transform.position;
    }
    void Start()
    {
        S = this;
        numLives = 3;
        level = 1;
        numBall = GameObject.FindGameObjectsWithTag("Balloon").Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("GameOver");

            }
        }

        DisplayTime(timeRemaining);

        levelText.text = $"Level: {level}";
        remainingLivesTxt.text = "Lives:";
        for(int i = 0; i < numLives; i++)
        {
            remainingLivesTxt.text += " X";
        }

        if(numLives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (numBall <= 0)
        {
            SceneManager.LoadScene("NextLevel");
        }


    }

    public void SpawnBee()
    {
        timerIsRunning = true;
        Instantiate(BeeFab, sp.transform.position, Quaternion.identity);
        spawnButton.SetActive(false);
        Debug.Log("Bee Spawned");
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
