using UnityEngine;

public class Boom_Animated : MonoBehaviour
{
    public float Speed_Y;
    public float Speed_Z;


    public float Speed;
    public double Timer = 0d;
    public double TimeLimit = 0d;
    public Vector3 scale = new Vector3(0, 0, 0);
    public Vector3 scaleLimit = new Vector3(0, 0, 0);

    public Follow_Camera_Player Camera_Player;
    void Start()
    {
        Camera_Player = GameObject.FindAnyObjectByType<Follow_Camera_Player>();
    }
    void LateUpdate()
    {
        if (Camera_Player.offset.y > 8.01f)
        {
            Camera_Player.offset.y -= Speed_Y * Time.deltaTime;
        }

        if (Camera_Player.offset.z > 4.01f)
        {
            Camera_Player.offset.z -= Speed_Z * Time.deltaTime;
        }

        transform.localScale += Vector3.Lerp(scale, scaleLimit, Speed * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer >= TimeLimit)
        {
            Destroy(gameObject);
            Camera_Player.offset.x = 8f;
            Camera_Player.offset.z = 4f;
        }
    }
}
