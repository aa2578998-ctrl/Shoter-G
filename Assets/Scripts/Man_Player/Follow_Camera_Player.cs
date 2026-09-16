using UnityEngine;
public class Follow_Camera_Player : MonoBehaviour
{
    // За кем повторяет
    public GameObject PL;
    // Смещение в 3D пронстранстве
    public Vector3 offset = new Vector3(0, 0, 0);
    // Смещение по вращении
    public Quaternion initialR;
    void LateUpdate()
    {
        // повторение позиции с смещением
        transform.position = PL.transform.position + offset;
        // повторение градуса поворота
        transform.rotation = initialR;
    }
}
