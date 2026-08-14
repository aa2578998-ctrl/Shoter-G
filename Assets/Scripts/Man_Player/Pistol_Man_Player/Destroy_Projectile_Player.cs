using UnityEngine;

public class Destroy_Projectile_Player : MonoBehaviour
{
    public HP_Slider_Player HPB;
    public float currentHP;
    private void Start()
    {
        HPB = GameObject.FindAnyObjectByType<HP_Slider_Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyS1"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Boss_1"))
        {
            Destroy(gameObject);
            HPB.SetHPslider(currentHP);
        }
    }
}
