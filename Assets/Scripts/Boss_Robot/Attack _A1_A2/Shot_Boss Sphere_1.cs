using UnityEngine;
public class Shot_BossSphere_1 : MonoBehaviour
{
    public Rotate_Sphere_Boss Quanity; // 
    public Attack_Boss_Alongtheline attack1;
    public Attack_Boss_JumpInPlayer attack2;

    public LayerMask Player; //
    public GameObject projectile; // 
    public Vector3 offsetR = new Vector3 (0, 0, 0); // 

    public bool StartTriggers; // 
    public bool Trigger; // 
    public bool TimeCooldown = false; //
    public bool PattronsStart; //

    public float currentTime = 0f; //
    public float DistanceAim; // 
    public float TimeMiniCD; //
    public float currentTimeMiniCD; //

    public int PrimaryPattrons; //
    public int QuanityPattrons; //
    public int AttackChoice;
    void Start()
    {
        QuanityPattrons = PrimaryPattrons; //
        attack2 = GameObject.FindAnyObjectByType<Attack_Boss_JumpInPlayer>();
        attack1 = GameObject.FindAnyObjectByType<Attack_Boss_Alongtheline>(); // 
        Quanity = GameObject.FindAnyObjectByType<Rotate_Sphere_Boss>(); //
    }

 void LateUpdate()
    {
        Quaternion offsetRotation = Quaternion.Euler(offsetR); //
        Vector3 ray = transform.rotation * (offsetRotation * Vector3.forward); // 

        Trigger = Physics.Raycast(transform.position, ray, DistanceAim, Player); // 
        if (PattronsStart && Trigger && StartTriggers) // 
        {
            Instantiate(projectile, transform.position, transform.rotation * offsetRotation); // 

            QuanityPattrons -= 1; // 
            PattronsStart = false; // 
        }
        if (QuanityPattrons <= 0) // 
        {
            StartTriggers = false; // 
            TimeCooldown = true; // 
            if (TimeCooldown) // 
            {
                currentTime += Time.deltaTime; // 
                if (currentTime >= 3f) // 
                {
                    StartTriggers = true; // 
                    TimeCooldown = false; // 

                    currentTime = 0f; // 

                    QuanityPattrons = PrimaryPattrons; // 
                    Quanity.QuanityAttack1 += 1; // 

                }
            }
        }
        if (!PattronsStart) // 
        {
            currentTimeMiniCD += Time.deltaTime; // 
            if (currentTimeMiniCD >= TimeMiniCD) //
            {
                currentTimeMiniCD = 0; // 
                PattronsStart = true; // 
            }
        }
        if (Quanity.QuanityAttack1 >= Quanity.FiniteQuanityAttavk1) // 
        {
            AttackChoice = Random.Range(1, 3);
            Quanity.QuanityAttack1 = 0;
        }
        if (AttackChoice >= 2 && AttackChoice > 0)
        {
            attack2.Attack2();
            AttackChoice = 0;
        }
        if (AttackChoice >= 1 && AttackChoice > 0)
        {
            attack1.Attack1();
            AttackChoice = 0;
        }
    }
    void OnDrawGizmosSelected()
    {
        Quaternion offsetRotate = Quaternion.Euler(offsetR); // 
        Vector3 rotationOffset = transform.rotation * (offsetRotate * Vector3.forward); //

        if (Application.isPlaying && Trigger) // 
        {
            Gizmos.color = Color.darkGreen; // 
        }
        else // 
        {
            Gizmos.color = Color.darkRed; // 
        }
        Gizmos.DrawLine(transform.position, transform.position + rotationOffset * DistanceAim); // 
    }
}
