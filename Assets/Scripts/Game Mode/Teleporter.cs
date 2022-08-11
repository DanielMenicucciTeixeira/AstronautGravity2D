using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    public bool IsWorking = true;
    public GameObject TeleporterBeam;
    public string NextScene;

    public void SwitchWorking(bool State)
    {
        IsWorking = State;
        TeleporterBeam.GetComponent<Renderer>().enabled = IsWorking;
    }

    void OnTriggerEnter2D(Collider2D OtherColliderComponent)
    {
        if(IsWorking)
        {
            if (OtherColliderComponent.gameObject.GetComponent<PlayerBody>())
            {
                SceneManager.LoadScene(NextScene);
                Debug.Log(OtherColliderComponent.gameObject.name);
            }
        }  
    }
	// Use this for initialization
	void Start ()
    {
        TeleporterBeam.GetComponent<Renderer>().enabled = IsWorking;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
