using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UltimateCC;

public class Boss1Manager : MonoBehaviour
{
    [HideInInspector] public GameObject Player;
    [HideInInspector] public Transform Target;
    [HideInInspector] public PlayerMain playerMain;
    private EnemyHealthSystem healthSystem;
    private Animator anim;
    private Rigidbody2D rigid;
    public GameObject bossAttackBox;
    private BossAttackBox bossAttack;
    public GameObject dashSmoke;

    public GameObject smallThrowable;
    public GameObject middleThrowable;
    public GameObject bigThrowable;


    public float moveSpeed;
    [HideInInspector] public bool notDead;
    public bool canAttack;
    private bool InAnimation;
    [HideInInspector] public bool stunned;
    [HideInInspector] public bool charging;

    public float setmeleeWaitTime;
    private float meleeWaitTime;
    public float meleerange;
    public float jumpRange;

    [Header("Skills")]

    [HideInInspector] public bool inSkillUse;

    [HideInInspector] public int rageStatus;

    //charge
    public float chargeKnockbackForce;
    public float setchargeSkillTime;
    private float chargeSkillTime;
    [HideInInspector] public bool backingUpTimer;
    private Vector2 chargingDir;


    //jump
    public GameObject explosionEffect;
    public float setCount;
    private float count;
    public float setjumpSkillTime;
    private float jumpSkillTime;
    public float jumpForce;
    private bool onAir;
    private Vector2 directionJump;
    private Vector2 controlPoint;
    


    //throw
    private GameObject willThrow;
    private bool gotoItem;
    private float calculation;


    //rage
    public GameObject QTEIndicator;

    //disable attack hitbox if non damage move

    public bool TEST;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<EnemyHealthSystem>();
        bossAttack = GetComponent<BossAttackBox>();
        //playerMain = PlayerMain.Instance;
        

        TEST = false;

        notDead = true;
        canAttack = false;
        InAnimation = false;
        charging = false;
        inSkillUse = false;
        backingUpTimer = false;
        gotoItem = false;

        rageStatus = 0;

        chargeSkillTime = setchargeSkillTime;
        meleeWaitTime = setmeleeWaitTime;
    }



    private void FixedUpdate()
    {
        if (notDead)
        {
            if (!stunned && !charging && !gotoItem)
            {
                if (canAttack && Player.transform.position.x - transform.position.x < 0)
                {
                    dashSmoke.GetComponent<SpriteRenderer>().flipX = false;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    dashSmoke.GetComponent<SpriteRenderer>().flipX = true;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            //                                %70                                                         %50                                                         %32                                                          %5
            if (((((healthSystem.currentHealth <= 42000f && rageStatus < 0) || (healthSystem.currentHealth <= 30000f && rageStatus < 1) || (healthSystem.currentHealth <= 18000f && rageStatus < 2) || (healthSystem.currentHealth <= 3000f)) && rageStatus <= 4) || TEST) && !inSkillUse && !InAnimation && !stunned)
            {
                inSkillUse = true;
                TEST = false;
                rageStatus += 1;
                WhatToThrow();
            }




            //timers
            
            if (canAttack)
            {
                if (meleeWaitTime > 0)
                    meleeWaitTime -= Time.deltaTime;

                if (chargeSkillTime > 0)
                    chargeSkillTime -= Time.deltaTime;

                if (jumpSkillTime > 0)
                    jumpSkillTime -= Time.deltaTime;
            }

        }
}



    void Update()
    {
        if (notDead && !stunned)
        {

            if (canAttack)  //player in range
            {
                //skill stuff

                if (backingUpTimer)
                {
                    Vector2 directionTarget = Target.position - transform.position;
                    rigid.MovePosition((Vector2)transform.position + (directionTarget * moveSpeed * 20 * Time.deltaTime));
                }

                if (onAir)
                {
                    if (count < setCount)
                    {
                        count += Time.deltaTime;

                        Vector3 m1 = Vector3.Lerp(transform.position, controlPoint, count);
                        Vector3 m2 = Vector3.Lerp(controlPoint, directionJump, count);
                        rigid.MovePosition(Vector3.Lerp(m1, m2, count));
                    }
                }

                if (gotoItem)
                {
                    calculation = Mathf.Abs(Vector2.Distance(willThrow.transform.position, transform.position));

                    Vector2 directionItem = willThrow.transform.position - transform.position;
                    rigid.MovePosition((Vector2)transform.position + (directionItem * 3.5f * moveSpeed * Time.deltaTime));
                }



                if (charging)
                {
                    float testingIfDamaged = PlayerMain.Instance.playerHealthSystem.CurrentHealth;
                    if (testingIfDamaged > PlayerMain.Instance.playerHealthSystem.CurrentHealth)
                    {
                        anim.Play("flex");
                        bossAttackBox.GetComponent<Animator>().Play("flex");
                        charging = false;
                    }

                    rigid.MovePosition((Vector2)transform.position + (chargingDir * moveSpeed * 5 * Time.deltaTime));
                }

                //moveset

                if (!inSkillUse && !TEST)
                {
                    //how far is the player

                    float distance = Vector2.Distance(Player.transform.position, transform.position);


                    /*if (PlayerMain.Instance.playerHealthSystem.CurrentHealth <= 0)         // for short Boss will be in a special scene so if player dies they restart the battle(SCENE)
                        anim.Play("flex");                                              // so no need to restart boss's AI              
                    else */
                    if (distance < meleerange)
                    {
                        if (!InAnimation && (chargeSkillTime <= 0) && rageStatus >= 2)
                        {
                            StartCoroutine(Charge());
                            chargeSkillTime = setchargeSkillTime;
                        }
                        else if (meleeWaitTime <= 0)
                        {
                            //attackup/down
                            anim.Play("attackup");
                            bossAttackBox.GetComponent<Animator>().Play("attackup");
                            meleeWaitTime = setmeleeWaitTime;
                        }
                        else if (!InAnimation)
                        {
                            anim.Play("idle");       //this can be placed with another move so he doesnt wait on our head
                            bossAttackBox.GetComponent<Animator>().Play("idle");
                        }

                    }
                    else if (jumpRange < distance && !InAnimation && jumpSkillTime <= 0)
                    {
                        StartCoroutine(Jump());
                        jumpSkillTime = setjumpSkillTime;
                    }
                    else if (distance > (meleerange + 5f) && !InAnimation)
                    {
                        if (!InAnimation && (chargeSkillTime <= 0))
                        {
                            StartCoroutine(Charge());
                            chargeSkillTime = setchargeSkillTime;
                        }
                        else
                        {
                            anim.Play("move");
                            bossAttackBox.GetComponent<Animator>().Play("move");

                            Vector2 direction = Player.transform.position - transform.position;
                            rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
                        }
                    }

                }

            }
            else      //not able to attack
            {
                anim.Play("idle");
                bossAttackBox.GetComponent<Animator>().Play("idle");
            }

        }
        else if (stunned)
        {
            /*if (rageStatus >= 2)
            {
                float distance = Vector2.Distance(Player.transform.position, transform.position);
                if (distance < meleerange)
                {
                anim.Play("attackback");
                }
            }*/
        }else //is dead
        {
            InAnimation = false;
            inSkillUse = false;
            anim.Play("backstep");
            bossAttackBox.GetComponent<Animator>().Play("backstep");
        }
    }


    IEnumerator Charge()
    {
        inSkillUse = true;
        anim.Play("backstep");
        bossAttackBox.GetComponent<Animator>().Play("backstep");
        dashSmoke.SetActive(true);

        yield return new WaitForSeconds(0.1f);   //giving time for the target set for boss
        backingUpTimer = true;

        yield return new WaitForSeconds(1.5f);

        backingUpTimer = false;
        anim.Play("willcharge");
        bossAttackBox.GetComponent<Animator>().Play("willcharge");

        yield return new WaitForSeconds(1.5f);

        dashSmoke.SetActive(false);
        chargingDir = Player.transform.position - transform.position;
        charging = true;
        anim.Play("charge");
        bossAttackBox.GetComponent<Animator>().Play("charge");
    }

    
    IEnumerator Jump()
    {
        inSkillUse = true;
        anim.Play("willjump");
        bossAttackBox.GetComponent<Animator>().Play("willcharge");
        yield return new WaitForSeconds(1.5f);

        anim.Play("attackjump");
        bossAttackBox.GetComponent<Animator>().Play("attackjump");

        rigid.constraints -= RigidbodyConstraints2D.FreezePositionY;

        rigid.AddForce(transform.up * jumpForce);

        //directionJump = new Vector3(Player.transform.position.x, Player.transform.position.y - 10, Player.transform.position.z) - transform.position;
        directionJump = new Vector2(Player.transform.position.x, Player.transform.position.y - 5f);


        controlPoint = ((transform.position + Player.transform.position) / 2f) + new Vector3(0f,15f,0f);

        /*
        if (GetComponent<SpriteRenderer>().flipX)
        {
            controlPoint = new Vector2(transform.position.x - 7f, transform.position.y + 9f);
        }
        else
        {
            controlPoint = new Vector2(transform.position.x + 7f, transform.position.y + 9f);
        }
        */

        count = 0f;
        onAir = true;

        yield return new WaitForSeconds(0.85f); //do it better  no

        explosionEffect.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        rigid.velocity = Vector3.zero;




        onAir = false;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        rigid.constraints -= RigidbodyConstraints2D.FreezePositionX;

        chargeSkillTime += 5f;

        yield return new WaitForSeconds(1.5f); //do it better 

        explosionEffect.SetActive(false);

        inSkillUse = false;
    }

    void WhatToThrow()
    {
        switch (rageStatus)
        {
            case 1:
                willThrow = smallThrowable;
                StartCoroutine(Throwing());
                break;

            case 2:
                willThrow = middleThrowable;
                StartCoroutine(Throwing());
                break;

            case 3:
                willThrow = bigThrowable;
                StartCoroutine(Throwing());
                break;

            case 4: //qte
                StartCoroutine(Charge());
                break;
        }
    }

    public IEnumerator Throwing()
    {

        yield return new WaitForSeconds(0.5f);  //for calculating idk

        gotoItem = true;
        anim.Play("move");
        bossAttackBox.GetComponent<Animator>().Play("move");

        yield return new WaitUntil(() => calculation < 3.5f);

        if (calculation >= 3.5f)
        {
            StartCoroutine(Throwing());
            yield break;
        }

        gotoItem = false;

        //animator pick up item
        anim.Play("flex");
        bossAttackBox.GetComponent<Animator>().Play("flex");
        yield return new WaitForSeconds(1f);

        //animator throw item

        willThrow.GetComponent<BossThrowableObject>().ThrowItem(Player);
        willThrow = null;

        yield return new WaitForSeconds(2f);

        inSkillUse = false;
    }

    public IEnumerator Stun()
    {
        charging = false;
        stunned = true;

        anim.Play("chargefail");
        bossAttackBox.GetComponent<Animator>().Play("chargefail");

        if (rageStatus >= 2)
        {
            yield return new WaitForSeconds(1f);
            anim.Play("attackback");
            bossAttackBox.GetComponent<Animator>().Play("attackback");
            yield return new WaitForSeconds(1f);
        }
        else
            yield return new WaitForSeconds(4f);

        inSkillUse = false;
        meleeWaitTime = setmeleeWaitTime;
        stunned = false;

        if(rageStatus >= 4)
            StartCoroutine(Charge());
    }

    public IEnumerator ChargeOk()
    {
        charging = false;

        anim.Play("flex");
        bossAttackBox.GetComponent<Animator>().Play("flex");

        //hasar player here

        if (!GetComponent<SpriteRenderer>().flipX) // sola bakan boss
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(chargeKnockbackForce, 1000f));
        else
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-chargeKnockbackForce, 1000f));

        yield return new WaitForSeconds(1f);


        if (rageStatus < 4)
            inSkillUse = false;
        meleeWaitTime = setmeleeWaitTime;
    }

    public void AnimationTime(int answer)
    {
        if (answer > 0)
            InAnimation = true;
        else
            InAnimation = false;
            
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, jumpRange);
        Gizmos.DrawWireSphere(transform.position, meleerange);
    }
}
