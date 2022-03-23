using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackgroundScrollerTest : MonoBehaviour
{
    
    public Rigidbody2D rigidbody;

    private float width;
    private float scrollSpeed = -15f;



    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
        width = 20.48f;
        
        rigidbody.velocity = new Vector2(scrollSpeed, 0);
        ResetPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetPlatforms();
        }
    }

    void ResetPlatforms()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(0, -4), 0);
    }
}
