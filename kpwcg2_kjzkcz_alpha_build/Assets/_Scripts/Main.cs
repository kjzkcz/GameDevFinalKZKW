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
        levelText.text = $"Level: {level}";
        remainingLivesTxt.text = "Lives:";
        for(int i = 0; i < numLives; i++)
        {
            remainingLivesTxt.text += " X";
        }

        if(numLives <= 0 || numBall == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

    public void SpawnBee()
    {
        Instantiate(BeeFab, sp.transform.position, Quaternion.identity);
        spawnButton.SetActive(false);
        Debug.Log("Bee Spawned");
    }
}
