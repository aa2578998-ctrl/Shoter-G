using UnityEngine;

public class Shock_Wave_Animation_Boss : MonoBehaviour
{
    public float speed;
    public Vector3 scale = new Vector3(0, 0, 0);
    public Vector3 scaleLimit = new Vector3(0, 0, 0);
    public double Timer;
    public double StopTimer;
    void LateUpdate()
    {
        transform.localScale += Vector3.Lerp(scale, scaleLimit, speed * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer >= StopTimer)
        {
            Destroy(gameObject);
        }
    }
}
