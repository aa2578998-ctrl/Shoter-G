using UnityEngine;

public class Destroy_Projectile_Player : MonoBehaviour
{
    public HP_Slider_Boss HPB;
    public float currentHP;

    void Start()
    {
        HPB = FindAnyObjectByType<HP_Slider_Boss>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyS1"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Boss_1"))
        {
            Destroy(gameObject);
            HPB.currentHP -= currentHP;
        }
    }
}
