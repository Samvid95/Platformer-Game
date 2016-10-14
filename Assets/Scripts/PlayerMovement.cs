using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public float jumpSpeed;

    public GameObject bullet;
    public float bulletSpeed;
    public LevelManager levelManager;

    private float moveVelocity;
    private bool grounded;
    private Vector2 direction;

   
    Vector3 screenSize;
	// Use this for initialization
	void Start () {
        direction = new Vector2(1.0f, 0.0f);
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
	}
	
	// Update is called once per frame
	void Update () {
       
        moveVelocity = 0;
        if(shieldScript.ShieldVisible == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.R))
            {
                GetComponent<Animator>().SetBool("moveRight", true);
                moveVelocity += movementSpeed;
                direction.x = 1.0f;
                
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.L))
            {
                GetComponent<Animator>().SetBool("moveRight", false);
                moveVelocity -= movementSpeed;
                direction.x = -1.0f;
                
            }
            
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed, 0);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
               
                Fire();
               
            }
        }
        Debug.Log("Grounded value: "+grounded);

    }

    void Fire()
    {
        GameObject bullet1;
        bullet1 = Instantiate(bullet, new Vector3(transform.position.x + direction.x,transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed * direction.x, 0, 0);
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Hit")
        {
            Destroy(gameObject);
            levelManager.LoadLevel("Start");
            
        }

    }
    
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
