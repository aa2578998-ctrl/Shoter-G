using UnityEngine;

public class R2otate_Sphere_Enemy_2 : MonoBehaviour
{
    public float speedRotate;
    public Shipe_ball_enemy shipe_Ball_Enemy;

    void Update()
    {

        speedRotate = shipe_Ball_Enemy.Agent.speed * 50;


        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
