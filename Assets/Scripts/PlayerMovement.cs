using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public float jumpSpeed;

    public GameObject bullet;
    public float bulletSpeed;

    private float moveVelocity;
    private bool grounded;
    private Vector2 direction;
	// Use this for initialization
	void Start () {
        direction = new Vector2(1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
       
        moveVelocity = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity += movementSpeed;
            direction.x = 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
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

    void Fire()
    {
        GameObject bullet1;
        bullet1 = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed * direction.x, 0, 0);
    }
    void OnTriggerEnter2D()
    {
        grounded = true;
    }
    void OnTriggerExit2D()
    {
        grounded = false;
    }
}
