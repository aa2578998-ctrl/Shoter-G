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

    public bool SetActives = true;

    [Header("По хорошему ставить значения 1 и -1 ")] public float OppositeSignSpeedF;
    [SerializeField] public Transform Player;
    public Vector3 offest = new Vector3(0f, 0f, 0f);
    void Start()
    {
        Agent.speed = speedForward;
        Agent.angularSpeed = speedRotate;
        Player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (Player != null)
        {
            if (SetActives)
            {
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
        }
        if (BustSpeedF_d <= 2)
        {
            Agent.ResetPath();
            if (SetActives)
            {
                Agent.speed /= 1f;
            }
            SetActives = false;
            transform.Translate(Vector3.forward * Agent.speed * Time.deltaTime);
        }
    }
}
