using UnityEngine;
using System.Collections;

public class winScript : MonoBehaviour {

    public LevelManager levelManager;
	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            levelManager.LoadLevel("Start");
        }
    }
}
