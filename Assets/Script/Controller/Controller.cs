using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{


    public HumanMagic MAGhuman;
    public HumanAgi AGIhuman;
    public HumanSTR STRhuman;
    public Slot[] slots1, slots2, slots3;
    public float moveSpeed = 2f;

    private Rigidbody2D rigidbody2d;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
    int jumpCount = 0;

    void Start()
    {
        slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
        slots2[0].transform.position = transform.position + new Vector3(0, 0, 0);
        slots3[0].transform.position = transform.position + new Vector3(1, 0, 0);
        MAGhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
        AGIhuman.transform.position = transform.position + new Vector3(0, 0, 0);
        STRhuman.transform.position = transform.position + new Vector3(1, 0, 0);

        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        swaplocation();
        jump();
        

    }

    void swaplocation()
    {
        if (Input.GetKeyDown("q"))
        {
            slots1[0].transform.position = transform.position + new Vector3(1, 0, 0);
            slots2[0].transform.position = transform.position + new Vector3(0, 0, 0);
            slots3[0].transform.position = transform.position + new Vector3(-1, 0, 0);
            MAGhuman.transform.position = transform.position + new Vector3(1, 0, 0);
            AGIhuman.transform.position = transform.position + new Vector3(0, 0, 0);
            STRhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
            Debug.Log("You have Press Q Move Blue To Front");
        }
        else if (Input.GetKeyDown("w"))
        {
            slots2[0].transform.position = transform.position + new Vector3(1, 0, 0);
            slots3[0].transform.position = transform.position + new Vector3(0, 0, 0);
            slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
            AGIhuman.transform.position = transform.position + new Vector3(1, 0, 0);
            STRhuman.transform.position = transform.position + new Vector3(0, 0, 0);
            MAGhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
            Debug.Log("You have Press W Move Green To Front");
        }
        else if(Input.GetKeyDown("e"))
        {
            slots3[0].transform.position = transform.position + new Vector3(1, 0, 0);
            slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
            slots2[0].transform.position = transform.position + new Vector3(0, 0, 0);
            STRhuman.transform.position = transform.position + new Vector3(1, 0, 0);
            MAGhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
            AGIhuman.transform.position = transform.position + new Vector3(0, 0, 0);
            Debug.Log("You have Press E Move Red To Front");
        }
        
       
    }
    void jump()
    {
       
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            jumpCount++;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(circleCollider2D.bounds.center, circleCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
     
        return raycastHit2D.collider != null;
    }
}
