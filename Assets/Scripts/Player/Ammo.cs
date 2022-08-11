using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //Variables
    GravityGun Gun;
	
    //Functions

    void OnCollisionEnter2D(Collision2D OtherColliderComponent)
    {
        if(OtherColliderComponent.gameObject.GetComponent<PlayerBody>())
        {
            Gun.AddAmmo(1);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
	void Start ()
    {
        Gun = FindObjectOfType<GravityGun>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
