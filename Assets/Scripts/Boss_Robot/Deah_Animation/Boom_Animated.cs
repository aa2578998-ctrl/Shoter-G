using UnityEngine;

public class Boom_Animated : MonoBehaviour
{
    public Audio_Switced audio_Switced;

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
        Camera_Player = GameObject.FindAnyObjectByType<Follow_Camera_Player>();

        SpawnBoss = FindAnyObjectByType<Spawn_EnemyAndBoss_Follow_Player>();

        tMP_Scorekills_Boss = FindAnyObjectByType<TMP_Scorekills_Enemy>();

        audio_Switced = FindAnyObjectByType<Audio_Switced>();

    }
    void LateUpdate()
    {
        if (Camera_Player.offset.y > 10.01f)
        {
            Camera_Player.offset.y -= Speed_Y * Time.deltaTime;
        }

        if (Camera_Player.offset.z > 5.01f)
        {
            Camera_Player.offset.z -= Speed_Z * Time.deltaTime;
        }

        transform.localScale += Vector3.Lerp(scale, scaleLimit, Speed * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer >= TimeLimit)
        {
            SpawnBoss.BossActive = false;

            Destroy(gameObject);
            Camera_Player.offset.y = 10f;
            Camera_Player.offset.z = 5f;

            tMP_Scorekills_Boss.BossUpdateText();

            audio_Switced.AudioBattle1();
        }
    }
}
