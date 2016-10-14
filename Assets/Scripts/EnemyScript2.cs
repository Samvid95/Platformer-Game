using UnityEngine;
using System.Collections;

public class EnemyScript2 : MonoBehaviour {

    public float moveVelocity;
    public float Health;
    public LevelManager levelManager;

    public GameObject bullet;
    public float bulletSpeed;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Fire", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveVelocity, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Hit")
        {
            Health -= 100;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (coll.gameObject.tag == "Player")
        {
            levelManager.LoadLevel("Start");
            Debug.Log("This is the main thing: change the scene");
            Destroy(coll.gameObject);
        }
    }

    void Fire()
    {
        GameObject bullet1;
        bullet1 = Instantiate(bullet, new Vector3(transform.position.x , transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed * -1, 0, 0);

    }
    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
