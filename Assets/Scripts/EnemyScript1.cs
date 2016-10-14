using UnityEngine;
using System.Collections;

public class EnemyScript1 : MonoBehaviour {

    public float moveVelocity;
    public float Health;
    public LevelManager levelManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
        if(coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
            levelManager.LoadLevel("Start");
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
