using UnityEngine;
using System.Collections;

public class shieldScript : MonoBehaviour {

    public static bool ShieldVisible;
	// Use this for initialization
	void Start () {
        ShieldVisible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            ShieldVisible = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            ShieldVisible = false;
        }
        
	}
}
