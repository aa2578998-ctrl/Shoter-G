using UnityEngine;
public class Rotate_Sphere_Boss : MonoBehaviour
{
    public AI_Boss_FollowAanOthers Stopping; //
    public Attack_Boss_Alongtheline actives; //
    public float FastSpeedRotate; //
    public float InitialSpeedRotate; //
    public float SpeedRotate; //
    public float AtLightningSpeed;
    public float BustSpeedRotate; //
    public int QuanityAttack1; //
    public int FiniteQuanityAttavk1; //

    private void Start()
    {
        SpeedRotate = InitialSpeedRotate; //
        Stopping = GameObject.FindAnyObjectByType<AI_Boss_FollowAanOthers>(); //
        actives = GameObject.FindAnyObjectByType<Attack_Boss_Alongtheline>(); //
    }
    void LateUpdate()
    {
        if (actives.PreparationForAttack1 && Stopping) // 
        {
            transform.Rotate(Vector3.forward * FastSpeedRotate * Time.smoothDeltaTime); //
        }
        else if (!actives.PreparationForAttack1 && Stopping && actives.attack1 < 2f) //
        {
            transform.Rotate(Vector3.forward * (SpeedRotate + BustSpeedRotate) * Time.smoothDeltaTime); //
        }
        if (actives.attack1Active >= 2f)
        {
            transform.Rotate(Vector3.forward * AtLightningSpeed * Time.deltaTime);
        }
    }
}
