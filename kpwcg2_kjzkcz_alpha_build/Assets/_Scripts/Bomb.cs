using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject spawnButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bee")
        {
            Main.S.numLives -= 1;
            //Destroy(this.gameObject);
            ResetSpawn();
        }
    }
    private void ResetSpawn()
    {
        Destroy(GameObject.FindWithTag("Bee"));
        spawnButton.SetActive(true);
    }
}
