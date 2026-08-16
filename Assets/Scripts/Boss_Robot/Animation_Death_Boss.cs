using UnityEngine;
using UnityEngine.AI;

public class Animation_Death_Boss : MonoBehaviour
{
    public HP_Slider_Boss HPBoss;
    public AI_Boss_FollowAanOthers Off;
    public NavMeshAgent Agent;

    public float speedMove;
    public float speedRotate;

    public Transform player;

    public Vector3 offsetRotation = new Vector3(0f, 0f, 0f);
    void Start()
    {
        HPBoss = GameObject.FindAnyObjectByType<HP_Slider_Boss>();
        Off = GameObject.FindAnyObjectByType<AI_Boss_FollowAanOthers>();
        Agent = GetComponent<NavMeshAgent>();

        Agent.speed = speedMove;
        Agent.angularSpeed = speedRotate;
    }

    void LateUpdate()
    {
        if (player != null)
        {

        }
    }
}
