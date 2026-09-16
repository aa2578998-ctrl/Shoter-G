using UnityEngine;

public class Boom_damage_Player : MonoBehaviour
{
    public TMP_HP_Player tMP_HP_Player;
    public int damage = 0;
    private Transform player;
    void Start()
    {
        tMP_HP_Player = FindAnyObjectByType<TMP_HP_Player>();
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tMP_HP_Player.TakeDamage(damage);
        }
    }
}
