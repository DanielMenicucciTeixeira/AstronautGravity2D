using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //Variables

    public GameObject Ammo;

    //Functions
    
    void OnCollisionEnter2D (Collision2D OtherColliderComponent)
    {
        if(OtherColliderComponent.gameObject.GetComponent<MissileBehavior>())
        {
            Instantiate(Ammo, transform.position, transform.rotation);
            Destroy(gameObject);
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
