
using UnityEngine;

public class Forward_Projectile_Pistol : MonoBehaviour
{
    public float speed;
    public float timeCorrutine;
void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (timeCorrutine > 0f )
        {
            timeCorrutine -= Time.deltaTime;
        }    
        else
        {
            Destroy(gameObject);
        }
    }
}
