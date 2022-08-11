using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //Variables

    PlayerBody Target;
    public GameObject AimCrosshairs;
    public GameObject Missile;
    public GameObject AttackSpawnPoint;

    public float Speed;
    public float MaxHeigh;
    public float MinHeigh;
    bool UpOrDown = true;
    //Vector3 LastFramePosition = new Vector3 (0, 0, 0);

    public float AttackDelay;
    float LastAttackTime = 0;
    public float MissileFiringBaseChance;
    public float LaserFiringBaseChance;
    float MissileFiringChance = 0;
    float LaserFiringChance = 0;
    public float OnNoAttackChanceIncrement;

    LineRenderer LaserRenderer;
    public float LaserAimingTime;
    public float LaserFireDelay;
    public float LaserFireDuration;
    public float LaserBeamWidth;
    float LaserAimingStartTime;
    float LaserFireTime;
    bool IsAiming = false;
    bool IsFiring = false;
    bool HasFired = false;
    LayerMask PlayerMask;

    public int MaxHitPoints;
    int CurrentHitPoints;

    bool Invulnerable = false;
    public float InvulnerabilityDuration;
    float InvulnerabilityBeginTime;
    public float BlinkDelay;
    float TimeSiceLastBlink;

    //Functions

    public void TakeDamage(int Damage)
    {
        if (!Invulnerable)
        {
            CurrentHitPoints = CurrentHitPoints - Damage;
            if (CurrentHitPoints < 0)
            {
                Destroy(gameObject);
            }
            else MakeInvulnarable();
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

    void BossMovement()
    {
        if (UpOrDown)
        {
            if (transform.position.y < MaxHeigh) GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
            else UpOrDown = false;
        }

        else
        {
            if (transform.position.y > MinHeigh) GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
            else UpOrDown = true;
        }

        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0,0)) UpOrDown = !UpOrDown;
        //LastFramePosition = transform.position;
    }

    void BossAttack()
    {
        if (Time.timeSinceLevelLoad > LastAttackTime + AttackDelay)
        {
            float Chance = Random.Range(1, 100);

            if (Chance <= MissileFiringChance)
            {
                FireMissile();
                MissileFiringChance = MissileFiringBaseChance;
                LaserFiringChance = LaserFiringBaseChance;
            }
            else
            {
                if (Chance <= MissileFiringChance + LaserFiringChance)
                {
                    IsAiming = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    LaserAimingStartTime = Time.timeSinceLevelLoad;
                    if(Target) AimCrosshairs.transform.position = Target.gameObject.transform.position;
                    AimCrosshairs.GetComponent<Renderer>().enabled = true;
                    MissileFiringChance = MissileFiringBaseChance;
                    LaserFiringChance = LaserFiringBaseChance;
                }
                else//Every time the boss does not attack, there is a higher chance he will attack next time
                {
                    MissileFiringChance = MissileFiringChance + OnNoAttackChanceIncrement;
                    LaserFiringChance = LaserFiringChance + OnNoAttackChanceIncrement;
                }
            }

            LastAttackTime = Time.timeSinceLevelLoad;
        }
    }

    void AimLaserBeam()
    {
        if (IsFiring)
        {
            FireLaserBeam();
            return;
        }
        else if (Time.timeSinceLevelLoad - LaserAimingStartTime > LaserAimingTime)
        {
            LaserFireTime = Time.timeSinceLevelLoad;
            FireLaserBeam();
            return;
        }
        else
        {
            if(Target) AimCrosshairs.transform.position = Target.gameObject.transform.position;
        }
    }

    void FireLaserBeam()
    {
        IsFiring = true;

        if(HasFired == false && Time.timeSinceLevelLoad - LaserFireTime > LaserFireDelay)
        {
            LaserRenderer.SetPosition(0, AttackSpawnPoint.transform.position);
            LaserRenderer.SetPosition(1, (AimCrosshairs.transform.position - AttackSpawnPoint.transform.position)*10);
            LaserRenderer.enabled = true;
            HasFired = true;
            return;
        }

        if (HasFired == true && Time.timeSinceLevelLoad - LaserFireTime - LaserFireDelay <= LaserFireDuration)
        {
            Vector2 Direction = AimCrosshairs.transform.position - AttackSpawnPoint.transform.position;
            Direction.Normalize();
            RaycastHit2D HitResult = Physics2D.Raycast(AttackSpawnPoint.transform.position, Direction, Mathf.Infinity, PlayerMask);
            if (HitResult)
            {
                HitResult.collider.gameObject.GetComponent<PlayerBody>().TakeDamage(2);
                Debug.Log(HitResult.collider.gameObject.name);
            }
            return;
        }

        if (HasFired == true && Time.timeSinceLevelLoad - LaserFireTime - LaserFireDelay > LaserFireDuration)
        {
            LaserRenderer.enabled = false;
            AimCrosshairs.GetComponent<Renderer>().enabled = false;
            HasFired = false;
            IsFiring = false;
            IsAiming = false;
            return;
        }
    }

    void FireMissile()
    {
        Instantiate(Missile,AttackSpawnPoint.transform.position, AttackSpawnPoint.transform.rotation);
    }

	// Use this for initialization
	void Start ()
    {
        Target = FindObjectOfType<PlayerBody>();
        LastAttackTime = Time.timeSinceLevelLoad;
        MissileFiringChance = MissileFiringBaseChance;
        LaserFiringChance = LaserFiringBaseChance;
        CurrentHitPoints = MaxHitPoints;
        LaserRenderer = GetComponent<LineRenderer>();
        LaserRenderer.enabled = false;
        LaserRenderer.useWorldSpace = true;
        AimCrosshairs.GetComponent<Renderer>().enabled = false;
        PlayerMask = LayerMask.GetMask("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsAiming)
        {
            BossMovement();
            BossAttack();
        }
        else AimLaserBeam();

        if (Invulnerable) InvulnarabilityUpdate();
    }
	
}
