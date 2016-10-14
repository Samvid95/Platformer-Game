using UnityEngine;
using System.Collections;

public class shredder1 : MonoBehaviour {

    public LevelManager levelManager;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Collision!!!!");
            levelManager.LoadLevel("Start");
            Destroy(col.gameObject);
        }
    }
}
