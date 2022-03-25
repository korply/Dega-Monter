using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Rigidbody2D rigidbody;

    private float width;
    private float scrollSpeed = -1f;



    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        width = 20.48f;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(scrollSpeed, 0);

        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
  
        }
    }

 
}
