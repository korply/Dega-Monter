using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{


    public HumanMagic MAGhuman;
    public HumanAgi AGIhuman;
    public HumanSTR STRhuman;
    //public ClassTacker ClassTacker;
    public Slot[] slots1, slots2, slots3;
    public float moveSpeed = 2f;
    public bool statusisSTR;
    public bool statusisMAGIC;
    public bool statusisAGI;
    public bool statusisSTRDead;
    public bool statusisMAGICDead;
    public bool statusisAGIDead;
    public float coolDownStr;
    public float coolDownMagic;
    public float coolDownAgi;
    float lastSwap;

    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
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
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        statusisAGI = false;
        statusisMAGIC = false;
        statusisSTR = true;
        statusisAGIDead = false;
        statusisMAGICDead = false;
        statusisSTRDead = false;

    }
    void Update()
    {
        swaplocation();
        jump();
        // dead();

    }

    void swaplocation()
    {
        if (Time.time - lastSwap < coolDownAgi)
        {
            if (Input.GetKeyDown("q"))
            {
                slots1[0].transform.position = transform.position + new Vector3(1, 0, 0);
                slots2[0].transform.position = transform.position + new Vector3(0, 0, 0);
                slots3[0].transform.position = transform.position + new Vector3(-1, 0, 0);
                MAGhuman.transform.position = transform.position + new Vector3(1, 0, 0);
                AGIhuman.transform.position = transform.position + new Vector3(0, 0, 0);
                STRhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
                statusisSTR = false;
                statusisMAGIC = true;
                statusisAGI = false;
            }
        }
        lastSwap = Time.time;


        if (Time.time - lastSwap < coolDownAgi)
        {
            if (Input.GetKeyDown("w"))
            {
                slots2[0].transform.position = transform.position + new Vector3(1, 0, 0);
                slots3[0].transform.position = transform.position + new Vector3(0, 0, 0);
                slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
                AGIhuman.transform.position = transform.position + new Vector3(1, 0, 0);
                STRhuman.transform.position = transform.position + new Vector3(0, 0, 0);
                MAGhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
                statusisSTR = false;
                statusisMAGIC = false;
                statusisAGI = true;
            }
        }
        lastSwap = Time.time;

        if (Time.time - lastSwap < coolDownAgi)
        {
            if (Input.GetKeyDown("e"))
            {
                slots3[0].transform.position = transform.position + new Vector3(1, 0, 0);
                slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
                slots2[0].transform.position = transform.position + new Vector3(0, 0, 0);
                STRhuman.transform.position = transform.position + new Vector3(1, 0, 0);
                MAGhuman.transform.position = transform.position + new Vector3(-1, 0, 0);
                AGIhuman.transform.position = transform.position + new Vector3(0, 0, 0);
                statusisSTR = true;
                statusisMAGIC = false;
                statusisAGI = false;


            }
        }
        lastSwap = Time.time;
    }
    // void dead()
    // {
    //     if (statusisSTRDead == true)
    //     {
    //         slots3[0].transform.position = transform.position + new Vector3(-1, 0, 0);
    //         slots2[0].transform.position = transform.position + new Vector3(1, 0, 0);
    //         slots1[0].transform.position = transform.position + new Vector3(0, 0, 0);
    //         AGIhuman.transform.position = transform.position + new Vector3(1, 0, 0);
    //         MAGhuman.transform.position = transform.position + new Vector3(0, 0, 0);
    //         statusisAGI = true;
    //         statusisMAGIC = false;
    //         statusisSTR = false;
    //         Debug.Log("Str is dead");
    //     }
    //     else if (statusisMAGICDead == true)
    //     {
    //         slots3[0].transform.position = transform.position + new Vector3(0, 0, 0);
    //         slots2[0].transform.position = transform.position + new Vector3(1, 0, 0);
    //         slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
    //         AGIhuman.transform.position = transform.position + new Vector3(1, 0, 0);
    //         STRhuman.transform.position = transform.position + new Vector3(0, 0, 0);
    //         statusisAGI = true;
    //         statusisMAGIC = false;
    //         statusisSTR = false;
    //         Debug.Log("Magic is dead");
    //     }
    //     else if (statusisAGIDead == true)
    //     {
    //         slots3[0].transform.position = transform.position + new Vector3(0, 0, 0);
    //         slots2[0].transform.position = transform.position + new Vector3(1, 0, 0);
    //         slots1[0].transform.position = transform.position + new Vector3(-1, 0, 0);
    //         STRhuman.transform.position = transform.position + new Vector3(1, 0, 0);
    //         MAGhuman.transform.position = transform.position + new Vector3(0, 0, 0);
    //         statusisAGI = false;
    //         statusisMAGIC = true;
    //         statusisSTR = false;
    //         Debug.Log("Agi is dead");
    //     }
    // }
    void jump()
    {

        if (IsGrounded())
        {
            jumpCount = 0;
        }
        if (statusisSTR == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
            {
                float jumpVelocity = 10f;
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                jumpCount++;
            }
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.min, boxCollider2D.size, 0f, Vector2.down, .1f, platformsLayerMask);

        return raycastHit2D.collider != null;
    }
    public void damage()
    {
        if (statusisAGI == true)
        {
            AGIhuman.takeDamageAgi(20);
            Debug.Log("You AGI Take 20 Damage");
        }
        if (statusisMAGIC == true)
        {
            MAGhuman.takeDamageMagic(20);
            Debug.Log("You MAG Take 20 Damage");
        }
        if (statusisSTR == true)
        {
            STRhuman.takeDamageSTR(20);
            Debug.Log("You STR Take 20 Damage");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            damage();
        }
    }
}
