using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private float width = 40f;
    private float scrollSpeed = -8f;
    public GameObject[] resourceprefab;
    
    public BoxCollider2D boxCollider2D1;


    // Start is called before the first frame update
    void Start()
    {
      
        int randomIndex = Random.Range(0, resourceprefab.Length);

       
                var item = Instantiate(resourceprefab[randomIndex], new Vector3(transform.position.x + Random.Range(-4, -2), transform.position.y + Random.Range(1, 4), 0), Quaternion.identity);
                item.transform.parent = gameObject.transform;

                var item2 = Instantiate(resourceprefab[randomIndex], new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(1, 4), 0), Quaternion.identity);
                item2.transform.parent = gameObject.transform;

                var item3 = Instantiate(resourceprefab[randomIndex], new Vector3(transform.position.x + Random.Range(2, 4), transform.position.y + Random.Range(1, 4), 0), Quaternion.identity);
                item3.transform.parent = gameObject.transform;
        

        
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
