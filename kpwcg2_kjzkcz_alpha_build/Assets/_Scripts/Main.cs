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
    public int level;

    private int maxLevel = 3;

    //private int _level;

    ////level property
    //public int level
    //{
    //    get
    //    {
    //        return (_level);
    //    }

    //    set
    //    {
    //        _level = value;
    //    }
    //}

    public int numLives = 3;
    public int numBall;

    public Text timeText;
    public float timeAllotted = 240;
    private float timeRemaining;
    public bool timerIsRunning = false;

    private void Awake()
    {
        //GameObject Bee =Instantiate<GameObject>(BeeFab);
        //Bee.transform.position = this.transform.position;
    }

    void Start()
    {
        S = this;
        timeRemaining = timeAllotted;
        spawnButton.SetActive(true);
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
        if (numBall == 0)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        level++;
        // check if maxLevel reached
        if (level <= maxLevel)
        {
            Debug.Log($"Level Up, current level: {level}");
            SceneManager.LoadScene($"_Scene_{level - 1}");
            numBall = GameObject.FindGameObjectsWithTag("Balloon").Length;
        }
        else
        {
            //max level reached, load win screen
            SceneManager.LoadScene("YouWin");
        }
    }


    public void SpawnBee()
    {
        //Debug.Log("Onlick called");
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
