using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public float jumpSpeed;
    public GameObject projectile;
    public float projectileSpeed;

    private float moveVelocity;
    private bool grounded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed, 0);
        }
        moveVelocity = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity += movementSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity -= movementSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject projectile1 = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        projectile1.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileSpeed, transform.position.y, 0);
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
