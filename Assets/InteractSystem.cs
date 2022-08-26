using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSystem : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject related_object;
    public GameObject related_object2;
    public GameObject easingEditor;

    Rigidbody2D related_rigidbody; 
    Rigidbody2D player_rb; 
    Animator anim;
    
    Transform PlayerPosition;
    bool active = false;
    
    
    Vector2 movement;

    bool deneme = true;
    void Start()
    {
      
    }
    void Update()
    {
        if (this.tag != "Player")
            tagControl(isInRange);
        else if (this.tag == "Player" && deneme)
            move();
    }

    public void move()
    {
        player_rb = this.gameObject.GetComponent<Rigidbody2D>();
        movement.x = Input.GetAxisRaw("Horizontal"); //x'i unity �zerinden kapat�yoruz zaten hareket etmemi� oluyo 
        movement.y = Input.GetAxisRaw("Vertical");
        player_rb.MovePosition(player_rb.position + movement * 5f * Time.fixedDeltaTime);

    }
    void tagControl(bool isInRange)
    {

        if (this.tag == "stairs")
        {
            if (isInRange && !active)
                stairsActive();
            else if (!isInRange && active)
                stairsDeactive();

            
        }
       
        else if(this.tag == "platform")
        {
            
            anim = related_object2.GetComponent<Animator>();
            
            if (isInRange && !active)
                platformActive();
        }
       
        else if(this.tag=="boxcontrol")
        {
            related_rigidbody = related_object.GetComponent<Rigidbody2D>();

            if (isInRange && Input.GetKeyDown(interactKey) && !active)                  // etki alan�ndaysa ve do�ru tu�a basm��sa
                active = true;          //hareketi aktifle�tir player scripti enable false
            else if (isInRange && Input.GetKeyDown(interactKey) && active)              // etki alan�ndaysa, do�ru tu�a bir kez daha basm��sa
                active = false;         //hareketi iptal et player scripti enable true

            if (isInRange && active)             //etki alan�ndaysa ve hareket yetene�ini aktif etmi�se ili�kili event fonksiyonunu �a��r yani boxcontrol
                interactAction.Invoke();
        }
        else if(this.tag=="music")
        {
            if (isInRange && Input.GetKeyDown(interactKey))
                interactAction.Invoke();
           
        }
        else if(this.tag=="arrowtrigger")
        {
            if(isInRange && !active)
            {
                active = true;
                interactAction.Invoke();
            }
        }
    }
    
    void stairsActive()
    {
        interactAction.Invoke();
        active = true;
    }

    void stairsDeactive()
    {
        easingEditor.GetComponent<EasingEditor>().miniStairsCome();
        
        active = false;
    }
    void platformActive()
    {
        
        interactAction.Invoke();
        active = true;
        anim.SetBool("Trigger", true);
        

        StartCoroutine(backtoIdle());
    }
    IEnumerator backtoIdle()
    {
        yield return new WaitForSeconds(6); // WaitForSeconds is (first move time + delay time)
        
        anim.SetBool("Trigger", false);
        active = false;
        isInRange = false;
    }
    public void BoxControl()
    {
        Debug.Log("Do�ru tu�, hareket etcem");
        deneme = false;
        movement.x = Input.GetAxisRaw("Horizontal"); //x'i unity �zerinden kapat�yoruz zaten hareket etmemi� oluyo 
        movement.y= Input.GetAxisRaw("Vertical");
        related_rigidbody.MovePosition(related_rigidbody.position + movement * 0.5f * Time.fixedDeltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = true;
        if (collision.gameObject.CompareTag("box") && this.tag == "stairs")
            isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = false;
        
    }
}
