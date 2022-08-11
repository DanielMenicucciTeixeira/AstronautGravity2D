using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {

    //Variables

    GameObject LifeScore;
    public GameObject GameOverSkull;

    float DirectionAngle;

    public int MaxLives;
    public int StartLives;
    int CurrentLives;

    bool Invulnerable = false;
    public float InvulnerabilityDuration;
    float InvulnerabilityBeginTime;
    public float BlinkDelay;
    float TimeSiceLastBlink;

    //Functions
    public void TakeDamage(int Damage)
    {
        if(!Invulnerable)
        {
            CurrentLives = CurrentLives - Damage;
            if (CurrentLives <= 0) GameOver();
            LifeScore.GetComponent<LifeCounter>().SetCurrentLives(CurrentLives);
            MakeInvulnarable();
        }
    }

    void MakeInvulnarable()
    {
        Invulnerable = true;
        InvulnerabilityBeginTime = Time.timeSinceLevelLoad;
    }

    void InvulnarabilityUpdate()
    {
        if (Time.timeSinceLevelLoad - InvulnerabilityBeginTime < InvulnerabilityDuration)
        {
            if (Time.timeSinceLevelLoad - TimeSiceLastBlink > BlinkDelay)
            {
                if (gameObject.GetComponent<Renderer>().enabled) gameObject.GetComponent<Renderer>().enabled = false;
                else gameObject.GetComponent<Renderer>().enabled = true;

                TimeSiceLastBlink = Time.timeSinceLevelLoad;
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            Invulnerable = false;
        }

    }

    void GameOver()
    {
        Instantiate(GameOverSkull, new Vector3(0,0,-5), Camera.main.transform.rotation);
        Destroy(gameObject);
    }


	// Use this for initialization
	void Start ()
    {
        LifeScore = FindObjectOfType<LifeCounter>().gameObject;
        CurrentLives = StartLives;
        LifeScore.GetComponent<LifeCounter>().SetCurrentLives(CurrentLives);
        TimeSiceLastBlink = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DirectionAngle = Vector2.SignedAngle(GetComponent<Rigidbody2D>().velocity, new Vector2(1, 0));
        transform.rotation = Quaternion.Euler(0, 0, DirectionAngle);

        if (Invulnerable) InvulnarabilityUpdate();
    }
}
