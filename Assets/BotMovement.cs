using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
	private Vector3 _direction;
	private Rigidbody _rigidbody;
	private Carrier _carrier;

	// Start is called before the first frame update
    private void Awake()
    {
	    _carrier = GetComponent<Carrier>();
	    _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    void Start()
    {
        _direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    	_rigidbody.AddForce(_direction * GetThrust());
    }

    // Update is called once per frame
    void Update()
    {
    	float velocity = Mathf.Sqrt(Mathf.Pow(_rigidbody.velocity[0], 2) + Mathf.Pow(_rigidbody.velocity[2], 2));

    	if(velocity < GetVelocityThreshold()){
	    	_rigidbody.AddForce(_direction * GetThrust());
    	}
    }

    void OnTriggerEnter(Collider collider)
    {
        _direction = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
    	_rigidbody.AddForce(_direction * GetThrust());
    }
    
    private float GetThrust()
    {
	    if (_carrier.Infected)
	    {
		    return .2f;
	    }
	    else
	    {
		    return .25f;
	    }
    }
    private float GetVelocityThreshold()
    {
	    if (_carrier.Infected)
	    {
		    return .9f;
	    }
	    else
	    {
		    return 1f;
	    }
    }
}
