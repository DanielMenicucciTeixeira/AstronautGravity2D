using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    //Variables

    public float PullForce;
    public float PushForce;
    public int MaxAmmo;
    public int StartingAmmo;
    int CurrentAmmo = 0;
    public float MinDistance;

    //Functions
    
    void FireGravityGun (float Force)
    {
        Rigidbody2D[] SceneObjects = FindObjectsOfType<Rigidbody2D>();

        for (int i = 0; i < SceneObjects.Length; i++)
        {
            if(SceneObjects[i].tag == "Movable") SceneObjects[i].AddForce(GetGravityForce(SceneObjects[i], Force));
        }
    }

    void FireShockWave(float Force)
    {
        Rigidbody2D[] SceneObjects = FindObjectsOfType<Rigidbody2D>();

        for (int i = 0; i < SceneObjects.Length; i++)
        {
            if (SceneObjects[i].tag == "Movable") SceneObjects[i].AddForce(GetShockWaveForce(SceneObjects[i], Force));
        }
    }

    Vector2 GetGravityForce (Rigidbody2D Object, float Force)
    {
        Vector2 Direction = Object.transform.position - transform.position;
        float Distance = Vector3.Distance(transform.position, Object.transform.position);

        if (Distance > MinDistance) return (Force * Direction) / (Distance * Distance);
        else return new Vector2(0, 0);

    }

    Vector2 GetShockWaveForce (Rigidbody2D Object, float Force)
    {
        Vector2 Direction = Object.transform.position - transform.position;
        float Distance = Vector3.Distance(transform.position, Object.transform.position);

        if (Distance > MinDistance) return (Force * Direction) / (Distance);
        else return new Vector2(0, 0);
    }

    public void AddAmmo (int Amount)
    {
        CurrentAmmo = CurrentAmmo + Amount;
        if (CurrentAmmo > MaxAmmo) CurrentAmmo = MaxAmmo;
    }

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        CurrentAmmo = StartingAmmo;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (Input.GetMouseButton(0))
        {
            FireGravityGun(-PullForce);
        }
        else if (Input.GetMouseButtonDown(1) && CurrentAmmo > 0)
        {
            FireShockWave(PushForce);
            CurrentAmmo--;
        }
    }
}
