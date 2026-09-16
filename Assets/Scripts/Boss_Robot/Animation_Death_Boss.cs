using NUnit.Framework.Constraints;
using UnityEngine;

public class Animation_Death_Boss : MonoBehaviour
{
    public GameObject Boom;
    public AI_Boss_FollowAanOthers AI;
    public Attack_Boss_Alongtheline AIattack1;
    public Attack_Boss_JumpInPlayer AIattack2;
    public Rotate_Sphere_Boss Rotate_sphere_Boss;

    public HP_Slider_Boss hP_Slider_Boss;

    public float Timer;

    public GameObject GameObjectTeleport;

    void Start()
    {
        AI = GameObject.FindAnyObjectByType<AI_Boss_FollowAanOthers>();
        AIattack1 = GameObject.FindAnyObjectByType<Attack_Boss_Alongtheline>();
        AIattack2 = GameObject.FindAnyObjectByType<Attack_Boss_JumpInPlayer>();
        Rotate_sphere_Boss = GameObject.FindAnyObjectByType<Rotate_Sphere_Boss>();

        hP_Slider_Boss = GameObject.FindAnyObjectByType<HP_Slider_Boss>();

        GameObjectTeleport = GameObject.Find("Teleport_BossAndPlayer");

    }

    public void ActivatedDeath()
    {
        AI.enabled = false;
        AIattack1.enabled = false;
        AIattack2.enabled = false;
        Rotate_sphere_Boss.enabled = false;
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && AIattack1.GroundAnalis)
        {
            AIattack1.attack1Active = 0f;
            AIattack1.distance = 0f;

            AIattack1.MaxPatrons.QuanityAttack1 = 0;

            AI.enabled = true; //
            AIattack1.Agent.enabled = false;

            AIattack1.GroundAnalis = false;
        }
    }


    void LateUpdate()
    {
        if (!AIattack1.enabled)
            Timer += Time.deltaTime;
        if (Timer >= 1)
        {
            Instantiate(Boom, transform.position, Quaternion.identity);

            Destroy(gameObject);
            Timer = 0;
        }
        // Телепортация босса с пропости
        if (transform.position.y <= AI.DistanceStopFall)
        {
            transform.position = GameObjectTeleport.transform.position;
        }
    }
}