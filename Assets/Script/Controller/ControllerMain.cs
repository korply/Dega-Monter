using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMain : MonoBehaviour
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

    //jump var
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
    int jumpCount = 0;

    //Cooldown var
    private CooldownTimer _cooldownTimer;
    public float CooldownTimeInSeconds;


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

        //Cooldown setup
        _cooldownTimer = new CooldownTimer(CooldownTimeInSeconds);


    }
    void Update()
    {
        //Cooldown update
        _cooldownTimer.Update(Time.deltaTime);

        swaplocation();

        jump();
        // dead();

    }

    void swaplocation()
    {
     //_cooldownTimer.IsActive can't act
        //!_cooldownTimer.IsActive can act
             if (Input.GetKeyDown("q") && !_cooldownTimer.IsActive)
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
                _cooldownTimer.Start();
                     }
             if (Input.GetKeyDown("w") && !_cooldownTimer.IsActive)
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
            _cooldownTimer.Start();
                     }
             if (Input.GetKeyDown("e") && !_cooldownTimer.IsActive)
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
            _cooldownTimer.Start();
                      }
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
    //         
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
    //         
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
    //         
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
            
        }
        if (statusisMAGIC == true)
        {
            MAGhuman.takeDamageMagic(20);
            
        }
        if (statusisSTR == true)
        {
            STRhuman.takeDamageSTR(20);  
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (statusisAGI == true)
                return;
            else
            damage();
        }

        if (other.gameObject.tag == "BreakableWall")
        {
            if (statusisSTR == true)
                return;
            else
            damage();
        }
    }
}
