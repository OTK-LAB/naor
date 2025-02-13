using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class ReflectiveCube : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public bool hitMe = false;
    public bool hitWall = false;
    bool winwin = false;


    public GameObject correct_box;
    Collider2D boxhit=null;
    private void Start()
    {
    }
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    void Update()
    {
        if (hitWall)
        {
            winwin = true;
            Debug.Log("win: " + winwin);
        }
        if (hitMe)
        {
            ShootLaser();
        }   
        else if (this.tag!="wall" )
        {
            m_lineRenderer.SetPosition(0, m_transform.position);
            m_lineRenderer.SetPosition(1, m_transform.position);
            correct_box.GetComponent<ReflectiveCube>().hitMe = false;
           
        }
        
    }
    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right, defDistanceRay);
            Draw2DRay(laserFirePoint.position, _hit.point);
            if (_hit.collider.tag == "Box")
            {
                Debug.Log("carptim");
                boxhit = _hit.collider;
                Debug.Log(boxhit.gameObject);
               // correct_box = _hit.collider.gameObject;
                _hit.collider.GetComponent<ReflectiveCube>().enabled = true;
                _hit.collider.GetComponent<ReflectiveCube>().hitMe = true;
            }
            else if (_hit.collider.tag == "wall")
            {
                _hit.collider.GetComponent<ReflectiveCube>().enabled = true;
                _hit.collider.GetComponent<ReflectiveCube>().hitWall = true;
            }
            else
            {
                Debug.Log("geri �ektim");
                boxhit.GetComponent<ReflectiveCube>().hitMe = false;

            }
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
   
}
