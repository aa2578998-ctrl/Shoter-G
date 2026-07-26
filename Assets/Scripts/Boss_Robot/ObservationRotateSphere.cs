using UnityEngine;
public class ObservationRotateSphere : MonoBehaviour
{
    public float speedG = 1f;
    public Transform Player;
public void LateUpdate()
    {
        transform.Rotate(Vector3.right * speedG * Time.deltaTime);
        
    }
}
