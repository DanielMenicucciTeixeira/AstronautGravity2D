using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{

    //Variables
    public ParticleSystem ExplosionParticle;
    public float InitialSpeed;

    float DirectionAngle;


    void OnCollisionEnter2D (Collision2D OtherColliderComponent)
    {
        if(OtherColliderComponent.gameObject.GetComponent<PlayerBody>())
        {
            OtherColliderComponent.gameObject.GetComponent<PlayerBody>().TakeDamage(2);
            
        }
        else if(OtherColliderComponent.gameObject.GetComponent<BossBehavior>())
        {
            OtherColliderComponent.gameObject.GetComponent<BossBehavior>().TakeDamage(1);
        }

        Instantiate(ExplosionParticle, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().AddForce (new Vector2(-InitialSpeed, 0));
	}
	
	// Update is called once per frame
	void Update ()
    {

        DirectionAngle = Vector2.SignedAngle(GetComponent<Rigidbody2D>().velocity, new Vector2(-1, 0)) - 90;
        transform.rotation = Quaternion.Euler(0, 0, -DirectionAngle);

    }
    
}