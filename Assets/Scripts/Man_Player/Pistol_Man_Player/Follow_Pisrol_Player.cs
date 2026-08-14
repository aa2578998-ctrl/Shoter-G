using UnityEngine;
public class Follow_Pisrol_Player : MonoBehaviour
{
    // За кем преследует и повторяет
    public Transform PR;
    // Смещение градуса
    public Quaternion offset;
 void LateUpdate()
    {
        // Сам скрипт для повторения движений и вращений
        transform.SetLocalPositionAndRotation(PR.transform.position, PR.transform.rotation * offset);
    }
}
