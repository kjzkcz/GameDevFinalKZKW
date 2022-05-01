using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redzone : MonoBehaviour
{
    public GameObject Bee;
    public GameObject spawnButton;
    //public GameObject sp;
    // Start is called before the first frame update

    private void Awake()
    {
        //GameObject nb = makeBee();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bee IN");
        Main.S.numLives -= 1;
        ResetSpawn();

        //GameObject cloneBee = Instantiate(Bee, Bee.transform.position, Quaternion.identity);
        //Destroy(GameObject.FindWithTag("Bee"));
        //StartCoroutine(wait());
        //yield return new WaitForSeconds(5);
        //GameObject newBee;
        //newBee = makeBee();
    }

    private void ResetSpawn()
    {
        Destroy(GameObject.FindWithTag("Bee"));
        spawnButton.SetActive(true);
    }

    //private GameObject makeBee()
    //{
    //    GameObject Bee0 = Instantiate<GameObject>(Bee);
    //    Bee0.transform.position = sp.transform.position;
    //    Bee0.tag = "Bee";

    //    return Bee0;

    //}

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
    }
}
