using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    //private int numBall;
    // Start is called before the first frame update
    private void Awake()
    {
        //numBall = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }
    void Start()
    {
        //GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        //numBall = GameObject.FindGameObjectsWithTag("Balloon").Length;
        //Debug.Log("Num Balloons: " + numBall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Bee")
        {
            Debug.Log("Balloon Hit");
            Destroy(this.gameObject);
            Main.S.numBall -= 1;


        }

        //if (numBall= 0)
        //{
        //    Debug.Log("No More Balloons");
        //}

            
        }
    }
