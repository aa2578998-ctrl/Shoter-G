using UnityEngine;
public class RotateCrown : MonoBehaviour
{
    public float speedRo;
void LateUpdate()
    {
        transform.Rotate(Vector3.forward * speedRo * Time.deltaTime);
    }
}
