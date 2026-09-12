using UnityEngine;


public class R2otate_Sphere_Enemy_2 : MonoBehaviour
{
    public Shipe_ball_enemy shipe_Ball_Enemy;
    public float speedRotate;


    void LateUpdate()
    {
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
