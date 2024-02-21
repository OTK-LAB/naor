using System.Collections;
using System.Collections.Generic;
using UltimateCC;
using UnityEditor.Rendering;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    public bool Destroyed = false;
    public Item item;
    public float speed;
    
    private float daggerDamage;


    private void Awake()
    {
        daggerDamage = item.value;


        Vector3 directionVector;
        if (GameObject.Find("NewPlayer").transform.localScale.x > 0)
        {
            directionVector = transform.right ;
            transform.Translate(2, 0, 0);

            Quaternion target = Quaternion.Euler(0,0,-90);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
        }
        else
        {
            directionVector = -transform.right ;
            transform.Translate(-2, 0, 0);

            Quaternion target = Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);

        }

        gameObject.GetComponent<Rigidbody2D>().AddForce(directionVector * speed, ForceMode2D.Impulse);

    }
    void Start()
    {

    }

    void Update()
    {
        if (Destroyed)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("enemyBoom");
            col.gameObject.GetComponent<EnemyHealthSystem>().Damage(daggerDamage);
            Destroyed=true;
        }
    }
}