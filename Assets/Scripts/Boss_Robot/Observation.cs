using UnityEngine;
public class Observation : MonoBehaviour
{
    public float speedR = 1f;
    public Transform Player;
void LateUpdate()
    {
        Vector3 direction = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation * Quaternion.Euler(-90f, 0f, 0f), speedR * Time.deltaTime);
    }
}
