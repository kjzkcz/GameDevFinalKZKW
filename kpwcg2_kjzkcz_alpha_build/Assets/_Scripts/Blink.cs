using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blinkTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Show", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Show()
    {
        //Debug.Log("Show invoked");
        gameObject.SetActive(true);
        Invoke("Hide", blinkTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
        Invoke("Show", blinkTime / 2);
    }
}
