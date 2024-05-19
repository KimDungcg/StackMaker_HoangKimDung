using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private RaycastHit ray;
    [SerializeField] private float rayCastDistance;
    [SerializeField] private GameObject player;

    private bool isMoving = false;
    public GameObject PreDash;
    public GameObject DashParent;
    public LayerMask collisionLayer;
    public static Player instance;
    public Vector3 moveDirection;
    private Vector3 MousePos;
    //private int brickCount = 0;
    // Update is called once per frame

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        MoveMouse();
        //Inputkeyboard();
        if (isMoving)
        {
            Move();
        }
    }
    private void MoveMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            var minusVector = Input.mousePosition - MousePos;           
            if (minusVector.magnitude >= 50f)
            {
                minusVector.Normalize();
                if (Mathf.Abs(minusVector.x) > Mathf.Abs(minusVector.y))
                {
                    if (minusVector.x > 0)
                    {
                        moveDirection = Vector3.right;
                    }
                    else
                    {
                        moveDirection = Vector3.left;
                    }
                }
                else
                {
                    if (minusVector.y > 0)
                    {
                        moveDirection = Vector3.forward;
                    }
                    else
                    {
                        moveDirection = Vector3.back;
                    }
                }
            }
        }
        Ray ray = new Ray(transform.position, moveDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayCastDistance, collisionLayer))
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    private void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    //private void Inputkeyboard()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        //ismoving = true;
    //        moveDirection = Vector3.forward;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        //ismoving = true;
    //        moveDirection = Vector3.back;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        //ismoving = true;
    //        moveDirection = Vector3.left;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //ismoving = true;
    //        moveDirection = Vector3.right;
    //    }
    //    // kiem tra va cham
    //    Ray ray = new Ray(transform.position, moveDirection);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, rayCastDistance, collisionLayer))
    //    {
    //        isMoving = false;
    //    }
    //    else
    //    {
    //        isMoving = true;
    //    }
    //}
    // di chuyen 

    // an gach

    public void PickDash(GameObject dash)
    {
        dash.transform.SetParent(DashParent.transform);
        Vector3 pos = PreDash.transform.localPosition;
        pos.y -= 0.2f;
        dash.transform.localPosition = pos;
        Vector3 CharPostion = transform.localPosition;
        CharPostion.y += 0.2f;
        transform.localPosition = CharPostion;
        PreDash = dash;
        BoxCollider boxCollider = PreDash.GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        Vector3 BoxSize = boxCollider.size;
        BoxSize.z = 30f;
        boxCollider.size = BoxSize;

        //brickCount++;
        //UIManager.instance.SetPoint(brickCount);
    }

    public void ThrowDash()
    {
        if (DashParent.transform.childCount > 1)
        {
            // xoa gach
            GameObject del = DashParent.transform.GetChild(0).gameObject;

            Destroy(del);
            // ha chieu cao 
            Vector3 pos = player.transform.position;
            pos.y -= 0.2f;
            player.transform.position = pos;
        }
    }   
    //public int GetBrickCount()
    //{
    //    return brickCount;
    //}
}
