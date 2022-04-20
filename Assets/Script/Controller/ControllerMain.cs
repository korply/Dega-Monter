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
    public bool statusisSTR;
    public bool statusisMAGIC;
    public bool statusisAGI;

    public Resource_counter resource_counter;


    //jump var
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
    int jumpCount = 0;

    //Cooldown var
    private CooldownTimer _cooldownTimerSTR;
    private CooldownTimer _cooldownTimerMAG;
    private CooldownTimer _cooldownTimerAGI;
    public float CooldownTimeInSecondsSTR;
    public float CooldownTimeInSecondsAGI;
    public float CooldownTimeInSecondsMAG;
    public float TimeRemainingSTR;
    public float TimeRemainingAGI;
    public float TimeRemainingMAG;

    //invincibleTimer
    private CooldownTimer _cooldownTimerInvincible;
    public float CooldownTimeInSecondsInvincible;
    public float TimeRemainingInvincible;

    //Death event
    public bool playerIsDeath = false;

    //flashing
    public Flashing[] flashing;

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

        //Cooldown swap setup
        _cooldownTimerSTR = new CooldownTimer(CooldownTimeInSecondsSTR);
        _cooldownTimerAGI = new CooldownTimer(CooldownTimeInSecondsAGI);
        _cooldownTimerMAG = new CooldownTimer(CooldownTimeInSecondsMAG);

        //invincibleTimer setup
        _cooldownTimerInvincible = new CooldownTimer(CooldownTimeInSecondsInvincible);

        //flashing sprite setup
        flashing[0] = GameObject.Find("MAGhuman").GetComponent<Flashing>();
        flashing[1] = GameObject.Find("AGIhuman").GetComponent<Flashing>();
        flashing[2] = GameObject.Find("STRhuman").GetComponent<Flashing>();
        //flashing sprite duration = invincible time
        flashing[0].flashDuration = CooldownTimeInSecondsInvincible;
        flashing[1].flashDuration = CooldownTimeInSecondsInvincible;
        flashing[2].flashDuration = CooldownTimeInSecondsInvincible;
        //reset totalcoins
        Resource_Coin.totalCoins = 0;
    }
    void Update()
    {
        //Cooldown update
        _cooldownTimerSTR.Update(Time.deltaTime);
        _cooldownTimerAGI.Update(Time.deltaTime);
        _cooldownTimerMAG.Update(Time.deltaTime);
        TimeRemainingSTR = _cooldownTimerSTR.TimeRemaining;
        TimeRemainingAGI = _cooldownTimerAGI.TimeRemaining;
        TimeRemainingMAG = _cooldownTimerMAG.TimeRemaining;

        //invincibleTimer update
        _cooldownTimerInvincible.Update(Time.deltaTime);
        TimeRemainingInvincible = _cooldownTimerInvincible.TimeRemaining;

        swaplocation();

        jump();

        CheckDeath();

    }

    void swaplocation()
    {
     //_cooldownTimer.IsActive can't act
     //!_cooldownTimer.IsActive can act

            //MAG
             if (Input.GetKeyDown("q") && !_cooldownTimerMAG.IsActive && !MAGhuman.statusisMAGICDead)
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
                _cooldownTimerMAG.Start();
            //active healing
            AGIhuman.takeDamageAgi(-20);
            MAGhuman.takeDamageMagic(-20);
            STRhuman.takeDamageSTR(-20);
        }

             //AGI
             if (Input.GetKeyDown("w") && !_cooldownTimerAGI.IsActive && !AGIhuman.statusisAGIDead)
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
            _cooldownTimerAGI.Start();
                     }

             //STR
             if (Input.GetKeyDown("e") && !_cooldownTimerSTR.IsActive && !STRhuman.statusisSTRDead)
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
            _cooldownTimerSTR.Start();
                      }
    }

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
        if (!_cooldownTimerInvincible.IsActive)
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
            _cooldownTimerInvincible.Start();
            flashing[0].Flash();
            flashing[1].Flash();
            flashing[2].Flash();
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

        if (other.gameObject.tag == "DeathZone")
        {
            playerIsDeath = true;
        }
    }

    public void CheckDeath()
    {
        if(MAGhuman.statusisMAGICDead && STRhuman.statusisSTRDead && AGIhuman.statusisAGIDead)
        {
            playerIsDeath = true;
        }

        if(resource_counter.timeUp)
        {
            playerIsDeath = true;
        }
    }
}
