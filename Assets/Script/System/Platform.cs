using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    public Rigidbody2D rigidbody;
    private float width=30f;
    private float scrollSpeed = -9f;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(scrollSpeed, 0);
        if (transform.position.x < -width)
        {
            Destroy(this.gameObject);
        }
    }

}
