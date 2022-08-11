using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{

    //Variables
    int CurrentLives = 6;
    public GameObject Life6, Life5, Life4, Life3, Life2, Life1;


    //Functions
    public void SetCurrentLives(int Lives)
    {
        CurrentLives = Lives;
    }

    void SetLivesOnScreen()
    {
        if (CurrentLives > 6) CurrentLives = 6;
        else if (CurrentLives < 0) CurrentLives = 0;

        switch (CurrentLives)
        {
            case 6:
                Life6.GetComponent<Renderer>().enabled = true;
                Life5.GetComponent<Renderer>().enabled = true;
                Life4.GetComponent<Renderer>().enabled = true;
                Life3.GetComponent<Renderer>().enabled = true;
                Life2.GetComponent<Renderer>().enabled = true;
                Life1.GetComponent<Renderer>().enabled = true;
                break;

            case 5:
                Life6.GetComponent<Renderer>().enabled = false;
                Life5.GetComponent<Renderer>().enabled = true;
                Life4.GetComponent<Renderer>().enabled = true;
                Life3.GetComponent<Renderer>().enabled = true;
                Life2.GetComponent<Renderer>().enabled = true;
                Life1.GetComponent<Renderer>().enabled = true;
                break;

            case 4:
                Life6.GetComponent<Renderer>().enabled = false;
                Life5.GetComponent<Renderer>().enabled = false;
                Life4.GetComponent<Renderer>().enabled = true;
                Life3.GetComponent<Renderer>().enabled = true;
                Life2.GetComponent<Renderer>().enabled = true;
                Life1.GetComponent<Renderer>().enabled = true;
                break;

            case 3:
                Life6.GetComponent<Renderer>().enabled = false;
                Life5.GetComponent<Renderer>().enabled = false;
                Life4.GetComponent<Renderer>().enabled = false;
                Life3.GetComponent<Renderer>().enabled = true;
                Life2.GetComponent<Renderer>().enabled = true;
                Life1.GetComponent<Renderer>().enabled = true;
                break;

            case 2:
                Life6.GetComponent<Renderer>().enabled = false;
                Life5.GetComponent<Renderer>().enabled = false;
                Life4.GetComponent<Renderer>().enabled = false;
                Life3.GetComponent<Renderer>().enabled = false;
                Life2.GetComponent<Renderer>().enabled = true;
                Life1.GetComponent<Renderer>().enabled = true;
                break;

            case 1:
                Life6.GetComponent<Renderer>().enabled = false;
                Life5.GetComponent<Renderer>().enabled = false;
                Life4.GetComponent<Renderer>().enabled = false;
                Life3.GetComponent<Renderer>().enabled = false;
                Life2.GetComponent<Renderer>().enabled = false;
                Life1.GetComponent<Renderer>().enabled = true;
                break;

            case 0:
                Life6.GetComponent<Renderer>().enabled = false;
                Life5.GetComponent<Renderer>().enabled = false;
                Life4.GetComponent<Renderer>().enabled = false;
                Life3.GetComponent<Renderer>().enabled = false;
                Life2.GetComponent<Renderer>().enabled = false;
                Life1.GetComponent<Renderer>().enabled = false;
                break;

            default:
                Life6.GetComponent<Renderer>().enabled = true;
                Life5.GetComponent<Renderer>().enabled = true;
                Life4.GetComponent<Renderer>().enabled = true;
                Life3.GetComponent<Renderer>().enabled = true;
                Life2.GetComponent<Renderer>().enabled = true;
                Life1.GetComponent<Renderer>().enabled = true;
                break;
        }

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetLivesOnScreen();
    }
}
