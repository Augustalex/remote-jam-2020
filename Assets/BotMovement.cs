using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
	private Vector3 direction;
	private float thrust = .25f;
	private float velocityThreshold = 1f;

	private Rigidbody _rigidbody;

	// Start is called before the first frame update
    private void Awake()
    {
	    _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    void Start()
    {
        direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    	_rigidbody.AddForce(direction * thrust);
    }

    // Update is called once per frame
    void Update()
    {
    	float velocity = Mathf.Sqrt(Mathf.Pow(_rigidbody.velocity[0], 2) + Mathf.Pow(_rigidbody.velocity[2], 2));

    	if(velocity < velocityThreshold){
	    	_rigidbody.AddForce(direction * thrust);
    	}
    }

    void OnTriggerEnter(Collider collider)
    {
        direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    	_rigidbody.AddForce(direction * thrust);
    }
}
