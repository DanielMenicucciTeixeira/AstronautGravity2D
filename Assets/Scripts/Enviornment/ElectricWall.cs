using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWall : MonoBehaviour
{
    public int HazardDamage = 1;

    void OnCollisionEnter2D (Collision2D OtherColliderComponent)
    {
        if (OtherColliderComponent.gameObject.GetComponent<PlayerBody>())
        {
            OtherColliderComponent.gameObject.GetComponent<PlayerBody>().TakeDamage(HazardDamage);
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
