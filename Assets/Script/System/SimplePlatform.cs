using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private float width = 40f;
    private float scrollSpeed = -9f;
    public GameObject resourceprefab;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

        var item = Instantiate(resourceprefab, new Vector3(transform.position.x+Random.Range(-5,5), transform.position.y + Random.Range(1,4), 0), Quaternion.identity);
        item.transform.parent = gameObject.transform;

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
