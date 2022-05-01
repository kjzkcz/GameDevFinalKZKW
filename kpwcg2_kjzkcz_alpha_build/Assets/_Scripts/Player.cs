using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Vector3 direction = mousePosition - transform.position;
        //direction = direction.normalize;
        //rigidbody.velocity = speed * direction;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        Vector3 direction = mousePosition - transform.position;
        //direction = direction.normalize;
        rigidbody.velocity = speed * direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log(collision.gameObject.name);
            //rigidbody.velocity = ;
        }
    }
}
