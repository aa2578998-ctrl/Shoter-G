using UnityEngine;
using UnityEngine.AI;

public class Shipe_ball_enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float speedForward = 2;
    public float speedRotate = 2;
    public float BustSpeedF_d;
    public float RatioASpeedF;
    public float LimiterSpeedingF;

    public int damage;

    public bool SetActives = true;

    public float HPenemy2;

    [Header("По хорошему ставить значения 1 и -1 ")] public float OppositeSignSpeedF;
    [SerializeField] public Transform Player;
    public Vector3 offest = new Vector3(0f, 0f, 0f);

    public R2otate_Sphere_Enemy_2 rotateSTOP;
    public Spawn_EnemyAndBoss_Follow_Player PointsSpawn;
    public TMP_HP_Player HP_Player;

    [Header("Таймер для вкл/выкл ИИ")]
    public float times;
    public float StopTimes;
    public float TimeDeath;
    public bool DeathTimes = false;
    public bool SetNotDeaht = true;
    void Start()
    {
        rotateSTOP = GameObject.FindAnyObjectByType<R2otate_Sphere_Enemy_2>();

        PointsSpawn = FindAnyObjectByType<Spawn_EnemyAndBoss_Follow_Player>();
        PointsSpawn.amountEAB++;

        HP_Player = FindAnyObjectByType<TMP_HP_Player>();

        Agent.speed = speedForward;
        Agent.angularSpeed = speedRotate;
        Player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (Player != null)
        {
            if (SetActives && SetNotDeaht)
            {

                rotateSTOP.speedRotate = rotateSTOP.shipe_Ball_Enemy.Agent.speed * 50;

                Agent.speed = speedForward + BustSpeedF_d / RatioASpeedF * OppositeSignSpeedF;
                Agent.SetDestination(Player.position);

                Vector3 rotationPAndA = transform.position - Player.transform.position;

                Quaternion rotates = Quaternion.LookRotation(rotationPAndA);
                Quaternion quaternion = Quaternion.Euler(offest);
                quaternion.x = 0f;
                quaternion.z = 0f;

                transform.rotation = Quaternion.Slerp(transform.rotation, rotates * quaternion, speedRotate * Time.deltaTime);

                BustSpeedF_d = Vector3.Distance(Player.transform.position, transform.position) / RatioASpeedF;
            }
            if (Agent.speed < LimiterSpeedingF)
            {
                Agent.speed = LimiterSpeedingF;
            }
        }

        if (BustSpeedF_d <= 2)
        {
            Agent.enabled = false;
            if (SetActives)
            {
                Agent.speed /= 2f;
            }
            SetActives = false;
            transform.Translate(Vector3.back * Agent.speed * Time.deltaTime);

            times += Time.fixedDeltaTime;
            if (times >= StopTimes)
            {
                times = 0;
                Agent.enabled = true;
                SetActives = true;
            }
        }
        if (DeathTimes)
        {
            Agent.enabled = false;
            SetNotDeaht = false;

            rotateSTOP.enabled = false;

            gameObject.GetComponent<Rigidbody>().freezeRotation = false;

            TimeDeath += Time.fixedDeltaTime;
            if (TimeDeath >= 1)
            {
                PointsSpawn.amountEAB--;

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Projectile Pl"))
        {
            HPenemy2 -= 1;
            if (HPenemy2 <= 0)
            {
                DeathTimes = true;
            }
        }
    }

    void OnCollisionStay(Collision collider2)
    {
        if (collider2.gameObject.CompareTag("Player"))
        {
            HP_Player.TakeDamage(damage);
        }
    }
}
