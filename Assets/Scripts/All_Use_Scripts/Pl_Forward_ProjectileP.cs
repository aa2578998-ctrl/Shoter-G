using UnityEngine;
public class PL_Forward_ProjectileP : MonoBehaviour
{
    public float speed; // 

    public float timeCorrutine; //

    public float scorees; //

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //
        if (timeCorrutine > 0f) //
        {
            timeCorrutine -= Time.deltaTime; //
        }
        else //
        {
            Destroy(gameObject); //
        }
    }
}
