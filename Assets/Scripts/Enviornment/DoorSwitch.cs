using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter2D (Collider2D OtherColliderComponent)
    {
        if(OtherColliderComponent.gameObject.GetComponent<PlayerBody>())
        {
            Door.GetComponent<Teleporter>().SwitchWorking(true);
        }
    }

	// Use this for initialization
	void Start ()
    {
		if(!Door.GetComponent<Teleporter>())
        {
            Debug.LogError("Invalid Door");
        }

        Door.GetComponent<Teleporter>().SwitchWorking(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
