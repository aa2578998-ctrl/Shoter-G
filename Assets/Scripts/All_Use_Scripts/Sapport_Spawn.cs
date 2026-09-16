using UnityEngine;

public class Sapport_Spawn : MonoBehaviour
{
    public Spawn_EnemyAndBoss_Follow_Player SapportS;
    public LayerMask Ground;
    public float LayerGround;
    void Start()
    {
        SapportS = FindAnyObjectByType<Spawn_EnemyAndBoss_Follow_Player>();
        bool director = Physics.Raycast(transform.position, Vector3.down, LayerGround, Ground);

        if (director)
        {
            SapportS.SpawnOthers();
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LayerGround);
    }
}
