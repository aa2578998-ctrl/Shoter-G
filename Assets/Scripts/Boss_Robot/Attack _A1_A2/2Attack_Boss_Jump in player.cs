using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Attack_Boss_JumpInPlayer : MonoBehaviour
{
    public Transform player;

    public AI_Boss_FollowAanOthers AIoff;
    public Rotate_Sphere_Boss StopRotate;
    public Shot_BossSphere_1 StopShot;
    public Shot_BossSphere_1 StopShot_1;
    public Area_Attack_2_Boss Area;

    public Vector3 scaleChanges = new Vector3(0f, 0f, 0f);
    public Vector3 JumpScaleChanges = new Vector3(0f, 0f, 0f);

    public float speedScale;
    public float speedScaleJump;
    public float speedJump;
    public float speedAttackJump;

    public float TimeForJump;
    public float TimeJump;
    public float TimeAttackJump;

    public bool StopScale;
    public bool StartCollision;
    public Sound_Manager sound_Manager;
    int s_M = 0;

    private void Start()
    {
        sound_Manager = FindAnyObjectByType<Sound_Manager>();


        player = GameObject.FindWithTag("Player").transform;

        AIoff = FindAnyObjectByType<AI_Boss_FollowAanOthers>();
        StopRotate = FindAnyObjectByType<Rotate_Sphere_Boss>();
        Area = FindAnyObjectByType<Area_Attack_2_Boss>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && StartCollision)
        {
            Area.HightOffset = 50f;
            TimeAttackJump = 0f;
            GetComponent<NavMeshAgent>().enabled = true;

            AIoff.enabled = true;
            StopShot.enabled = true;
            StopShot_1.enabled = true;
            StopRotate.enabled = true;

            transform.localScale = new Vector3(1f, 1f, 1f);
            StartCollision = false;
        }
    }

    public void LateUpdate()
    {
        if (StopScale)
        {
            if (s_M == 0)
            {
                s_M++;
                sound_Manager.Reproducte(12, gameObject, 0.4f);
            }

            TimeForJump += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, scaleChanges, speedScale * Time.deltaTime);
        }
        if (TimeForJump >= 1.5f)
        {
            if (s_M == 1)
            {
                s_M++;
                sound_Manager.Reproducte(13, gameObject, 0.5f);
            }

            StopScale = false;
            transform.localScale = Vector3.Lerp(transform.localScale, JumpScaleChanges, speedScaleJump * Time.deltaTime);
            GetComponent<Rigidbody>().useGravity = false;

            transform.Translate(Vector3.up * speedJump * Time.deltaTime);
            TimeJump += Time.deltaTime;
        }
        if (TimeJump >= 1f)
        {
            Area.HightOffset = 0.01f;
            TimeForJump = 0f;
            transform.position = new Vector3(player.position.x, 100f, player.position.z);
            TimeAttackJump += Time.deltaTime;
        }
        if (TimeAttackJump >= 0.3f)
        {
            TimeJump = 0f;
            transform.Translate(Vector3.down * speedAttackJump * Time.deltaTime);
            GetComponent<Rigidbody>().useGravity = true;
            StartCollision = true;

            if (s_M == 2)
            {
                s_M++;
                sound_Manager.Reproducte(14, gameObject, 1f);
            }
        }
    }

    public void Attack2()
    {
        if (AIoff != null)
        {
            AIoff.enabled = false;
            StopRotate.enabled = false;
            StopShot_1.enabled = false;
            StopShot.enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            StopScale = true;
            s_M = 0;
        }
    }
}
