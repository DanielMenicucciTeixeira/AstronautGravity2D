using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Variables
    public float IncreaseDelay;
    public float IncreaseMagnitude;
    float LastIncreaseTime = 0;
    public float Durantion;
    float GameOverTime;
    public GameObject FadeOut;

    //Functions

    void IncreseSkullSize()
    {
        if (Time.timeSinceLevelLoad - LastIncreaseTime > IncreaseDelay)
        {
            transform.localScale = transform.localScale * IncreaseMagnitude;
            LastIncreaseTime = Time.timeSinceLevelLoad;
        }
    }

	// Use this for initialization
	void Start ()
    {
        GameOverTime = Time.timeSinceLevelLoad;
        FadeOut.GetComponent<GameOverFadeOut>().FadeOut();
	}
	
	// Update is called once per frame
	void Update ()
    {
        IncreseSkullSize();

        if (Time.timeSinceLevelLoad - GameOverTime > Durantion)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
            Component.Destroy(this);
        }
    }

}
