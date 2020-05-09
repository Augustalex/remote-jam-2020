using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
	private Vector3 direction;
	private float thrust = .1f;
	private float velocityThreshold = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    	GetComponent<Rigidbody>().AddForce(direction * thrust);
    }

    // Update is called once per frame
    void Update()
    {
    	float velocity = Mathf.Sqrt(Mathf.Pow(GetComponent<Rigidbody>().velocity[0], 2) + Mathf.Pow(GetComponent<Rigidbody>().velocity[2], 2));

    	if(velocity < velocityThreshold){
	    	GetComponent<Rigidbody>().AddForce(direction * thrust);
    	}
    }

    void OnCollisionEnter(Collision collision)
    {
        direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    	GetComponent<Rigidbody>().AddForce(direction * thrust);
    }
}
