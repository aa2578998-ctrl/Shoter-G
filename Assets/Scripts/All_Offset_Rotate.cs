using UnityEngine;
public class All_Offset_Rotate : MonoBehaviour
{
    public Transform Subject;
    void LateUpdate()
    {
        transform.position = Subject.position;
    }
}
