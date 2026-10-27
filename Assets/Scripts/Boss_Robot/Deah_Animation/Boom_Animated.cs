using UnityEngine;

public class Boom_Animated : MonoBehaviour
{
    public float Speed_Y;
    public float Speed_Z;

    public Spawn_EnemyAndBoss_Follow_Player SpawnBoss;

    public float Speed;
    public double Timer = 0d;
    public double TimeLimit = 0d;
    public Vector3 scale = new Vector3(0, 0, 0);
    public Vector3 scaleLimit = new Vector3(0, 0, 0);

    public Follow_Camera_Player Camera_Player;

    public TMP_Scorekills_Enemy tMP_Scorekills_Boss;

    void Start()
    {
        SpawnBoss = FindAnyObjectByType<Spawn_EnemyAndBoss_Follow_Player>();

        tMP_Scorekills_Boss = FindAnyObjectByType<TMP_Scorekills_Enemy>();

    }

    void LateUpdate()
    {
        if (Camera_Player != null)
        {
            Camera_Player = GameObject.FindAnyObjectByType<Follow_Camera_Player>();
            if (Camera_Player.offset.y > 10.01f)
            {
                Camera_Player.offset.y -= Speed_Y * Time.deltaTime;
            }

            if (Camera_Player.offset.z > 5.01f)
            {
                Camera_Player.offset.z -= Speed_Z * Time.deltaTime;
            }

            if (!SpawnBoss.BossActive)
            {
                Camera_Player.offset.y = 10f;
                Camera_Player.offset.z = 5f;
            }
        }

        transform.localScale += Vector3.Lerp(scale, scaleLimit, Speed * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer >= TimeLimit)
        {
            SpawnBoss.BossActive = false;

            Destroy(gameObject);

            tMP_Scorekills_Boss.BossUpdateText();
        }
    }
}
