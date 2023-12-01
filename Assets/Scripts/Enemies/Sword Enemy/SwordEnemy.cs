using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class SwordEnemy : MonoBehaviour
{

    enum State
    {
        STATE_STARTINGMOVE,
        STATE_FOLLOWING,
        STATE_ATTACK,
        STATE_COOLDOWN,
        STATE_NOTDAMAGE,
        STATE_HIT,
        STATE_FROZEN,
        STATE_BACKTOWALL
    };

    State state = State.STATE_STARTINGMOVE;

    //Animations
    private Animator animator;
    private string currentState;
    const string idle = "Cooldown1";
    const string hit = "Hit1";
    const string attack = "Attack1";
    const string death = "Dead1";
    const string follow = "Run";
    const string startingmove = "StartingMove1";

    public Material material;

    //Movement
    bool Moveright = true;
    public int moveDirection = 1;
    [Header("Left Wall")]
    public GameObject wall;
    [Header("Right Wall")]
    public GameObject wall2;
    Vector3 startPoint;
    bool isBetweenWalls;
    float moveDirectionX;
    float step;

    //Following & CoolDown
    private GameObject player;
    private Transform playerPos;
    public float distance;
    float distanceToPlayer;
    public float moveSpeed;
    float firstmoveSpeed;
    
    //Slow
    public float slowRate;
    float slowSpeed;
    bool slow = false;
    float slowTime;

    //Attack
    Vector2 enemyPosition;
    [SerializeField] public GameObject attackPoint;
    [SerializeField] public float attackRange;
    [SerializeField] public float damageamount;
    bool attackable = true;

    bool IsDead = false;
    bool isHit = false;
    float verticalTolerance = 0.5f; //enemy alttayken player �stteyse onu alg�lamas�n diye eklendi
    float timer;
    //Hit
    Vector2 temp;
    public float knockbackDistance; //geri sekmesi
    Rigidbody2D rb;
    LayerMask enemyLayers;
    EnemyHealthSystem _healthSystem;

    public GameObject soul;
    private bool hasTurned = false;
    bool check;
    void Awake()
    {
        _healthSystem = GetComponent<EnemyHealthSystem>();
        animator = GetComponent<Animator>();
        _healthSystem.OnHit += OnHit;
        _healthSystem.OnDead += OnDead;

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        startPoint = transform.position;
        firstmoveSpeed = moveSpeed;
        slowSpeed = (firstmoveSpeed/100)*(100-slowRate);

    }

    void Update()
    {
        checkState();
        slowTimer();
    }
    void checkState()
    {
        switch (state)
        {
            case State.STATE_STARTINGMOVE:
                checkPlayer();
                ChangeAnimationState(startingmove);
                startingMove();
                break;
            case State.STATE_FOLLOWING:
                checkPlayer();
                ChangeAnimationState(follow);
                following();
                break;
            case State.STATE_ATTACK:
                rb.velocity = Vector2.zero;
                attacktoPlayer();
                break;
            case State.STATE_COOLDOWN:
                ChangeAnimationState(idle);
                coolDown(2);
                break;
            case State.STATE_HIT:
                hitState();
                break;
            case State.STATE_FROZEN:
                ChangeAnimationState(idle);
                rb.velocity = Vector2.zero;
                coolDown(5);
                break;
            case State.STATE_BACKTOWALL:
                ChangeAnimationState(startingmove);
                backtoWall();
                break;

        }
    }
    void startingMove()
    {
        if(!slow)
            moveSpeed = firstmoveSpeed; // ba�lang�� hareket h�z�
        moveDirectionX = moveDirection;
        step = moveSpeed * moveDirectionX;
        rb.velocity = new Vector3(step, rb.velocity.y);
    }
    void hitState()
    {
        if (isHit)
        {
            knockbackDistance = -0.5f;
            Vector2 knockbackVector = Moveright ? Vector2.right : Vector2.left;
            rb.MovePosition(rb.position + knockbackVector * knockbackDistance);

            ChangeAnimationState(hit);
            isHit = false;
            attackable = true;
        }
    }
    public void setState()
    {
        state = State.STATE_STARTINGMOVE;
    }

    void checkPlayer()
    {
        enemyPosition = new Vector2(rb.position.x, rb.position.y); // D��man�n konumu
     //   Vector2 playerPosition = new Vector2(playerPos.position.x, playerPos.position.y); // Oyuncunun konumu
        distanceToPlayer = Vector2.Distance(enemyPosition, playerPos.position);
        isBetweenWalls = transform.position.x >= wall.transform.position.x && transform.position.x <= wall2.transform.position.x;

        if (distanceToPlayer < distance && Mathf.Abs(enemyPosition.y - playerPos.position.y) < verticalTolerance)
        {
            hasTurned = false;
            if (distanceToPlayer <= 1)
                state = State.STATE_ATTACK;
            else
                state = State.STATE_FOLLOWING;
        }
        else if (isBetweenWalls)
            state = State.STATE_STARTINGMOVE;
           else
           {
            state = State.STATE_BACKTOWALL;
           }
            
    }
    void following()
    {
        flip();
        if(!slow)
            moveSpeed = firstmoveSpeed + 2;
        Vector2 currentPlayerPos = new Vector2(playerPos.position.x, rb.position.y);
        rb.velocity = (currentPlayerPos - rb.position).normalized * moveSpeed;
    }
    
    void backtoWall()
    {
        moveSpeed = firstmoveSpeed;
        Vector2 startDirection = startPoint - transform.position;
        if (!hasTurned && Vector3.Dot(startDirection, transform.right) < 0f)
        {
            hasTurned = true;
            if (Moveright) Moveright = false;
            else Moveright = true;
            moveDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
        rb.velocity = startDirection.normalized * moveSpeed ;
        checkPlayer();
        // Ba�lang�� konumuna ula�t���nda, Walking state'ine ge�
        if (Vector2.Distance(transform.position, startPoint) < 0.1f)
        {
            hasTurned = false;
            state = State.STATE_STARTINGMOVE;
        }
    }
    void attacktoPlayer()
    {
        if (attackable && !isHit)
        {
            ChangeAnimationState(attack);
            attackable = false;
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange);
            foreach (Collider2D enemy in hitPlayer)
            {
               // if (enemy.tag == "Player")
                    //player.GetComponent<HealthSystem>().Damage(damageamount);
            }
        }

    }
    public void slowTimer()
    {
        slowTime -= Time.deltaTime;
        if (slowTime <= 0f)
        {
            slowTime = 0f;
            speedFix();
        }
    }
    public void speedReduction(float time)
    {
        slowTime = time;
        moveSpeed = slowSpeed;
        slow = true;
    }
    public void speedFix()
    {
        moveSpeed = firstmoveSpeed;
        slow = false;
    }
    public void setFrozenState()
    {
        state = State.STATE_FROZEN;
    }
    IEnumerator backtoCoolDown()
    {
        if (!isHit)
        {
            yield return new WaitForSeconds(0.01f);
                state = State.STATE_COOLDOWN;
        }
        else
            state = State.STATE_HIT;
    }

    void coolDown(float i)
    {
     
        check = WaitForSeconds(i);
        if(check)
            checkPlayer();
    }
    private bool WaitForSeconds(float i)
    {
        timer += Time.deltaTime;
        if (timer >= i)
        {
            attackable = true;
            timer = 0;
            return true;
        }
        return false;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.CompareTag("wall") && state == State.STATE_STARTINGMOVE)
        {
            if (Moveright) Moveright = false;
            else Moveright = true;
            moveDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

    }

    void OnHit(object sender, EventArgs e)
    {
        if (!IsDead)
        {
            state = State.STATE_HIT;
            isHit = true;
        }
    }
    void OnDead(object sender, EventArgs e)
    {
        if (!IsDead)
        {
       //     StartCoroutine(SpawnSoul(0.8f)); ?????????????????
            IsDead = true;
            ChangeAnimationState(death);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        }
    }

    IEnumerator SpawnSoul(float wait)
    {
        yield return new WaitForSeconds(wait);
        Instantiate(soul, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity).GetComponent<SoulMovement>().player = player.transform;
        Instantiate(soul, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity).GetComponent<SoulMovement>().player = player.transform;
    }

    void flip()
    {
        if (playerPos.position.x > (transform.position.x + 0.5f))
        {
            if (!Moveright)
            {
                transform.Rotate(0f, 180f, 0f);
                Moveright = true;
                moveDirection *= -1;
            }
        }
        else
        {
            if (Moveright)
            {
                transform.Rotate(0f, 180f, 0f);
                Moveright = false;
                moveDirection *= -1;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
