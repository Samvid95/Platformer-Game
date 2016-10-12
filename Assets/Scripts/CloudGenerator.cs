using UnityEngine;
using System.Collections;

public class CloudGenerator : MonoBehaviour {

    public GameObject[] cloud;
    public float maxY, minY;
    public float maxX, minX;
    public float cloudSpeed;
    // Use this for initialization
	void Start () {
        
        
        InvokeRepeating("Generate", 2.0f, 2.0f);
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    void Generate()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            GameObject tempCloud;
            tempCloud = Instantiate(cloud[i], position, Quaternion.identity) as GameObject;
            tempCloud.GetComponent<Rigidbody2D>().velocity = new Vector3(-cloudSpeed, 0, 0);
            tempCloud.transform.parent = GameObject.Find("CloudController").transform;
        }
    }
}
