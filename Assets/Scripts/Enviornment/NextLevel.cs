using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public string nextLevel;
    public Collider2D levelDoor;
    bool IsWorking = true;

    public void SwitchIsWorking (bool State)
    {
        IsWorking = State;
    }

	// Use this for initialization
	void Start () {
        levelDoor = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsWorking) SceneManager.LoadScene(nextLevel);
    }
}
