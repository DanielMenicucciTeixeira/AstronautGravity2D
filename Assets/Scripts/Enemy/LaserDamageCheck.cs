using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageCheck : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D OtherCollisionComponent)
    {
        if(OtherCollisionComponent.gameObject.GetComponent<PlayerBody>())
        {
            OtherCollisionComponent.gameObject.GetComponent<PlayerBody>().TakeDamage(2);
        }
    }

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
