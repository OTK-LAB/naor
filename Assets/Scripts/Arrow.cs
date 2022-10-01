using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Arrow : MonoBehaviour
{

    Transform PlayerPosition;
    [SerializeField] private float daggerSpeed;
    private Rigidbody2D rb;
    private Vector2 direction;
    public static float daggerDamage = 5f;
    public static Arrow instance;
    float y, x;
    public bool left;
    public bool right;
    //public GameObject SpawnPoint;
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        Debug.Log("do�du g�ne�im"+rb.position);

        x = rb.transform.position.x;
        y = rb.transform.position.y;


        if (this.gameObject.tag == "uparrow")
            y = y + 1;
        else if (this.gameObject.tag == "downarrow")
            y = y - 0.4f;

        this.gameObject.transform.position = new Vector2(x, y);

        if (left) 
        { 
            direction = Vector2.left;
            this.gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }
        else if(right)
        {
            direction = Vector2.right;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        Destroy(gameObject, 5f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction*daggerSpeed;

    }
    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("arrowtrigger").GetComponent<InteractSystem>().arrowHit = true;
            GameObject.FindGameObjectWithTag("arrowtrigger").GetComponent<InteractSystem>().isInRange = false;
            //InteractSystemTrigger.GetComponent<InteractSystem>().arrowHit = true;
           // Debug.Log(InteractSystemTrigger.GetComponent<InteractSystem>().arrowHit);
            Debug.Log("dead");
            Destroy(gameObject);

        }

    }
}