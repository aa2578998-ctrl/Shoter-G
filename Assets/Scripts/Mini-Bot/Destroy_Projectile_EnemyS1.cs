using UnityEngine;
public class Destroy_Projectile_EnemyS1 : MonoBehaviour
{
    public int damage;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            TMP_HP_Player player = FindAnyObjectByType<TMP_HP_Player>();
            if (player != null)
                player.TakeDamage(damage);
        }
    }
}
