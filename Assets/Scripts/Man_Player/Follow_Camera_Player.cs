using UnityEngine;

public class Follow_Camera_Player : MonoBehaviour
{
    public GameObject PL;
    public Vector3 offset = new Vector3 (0, 0, 0);
    public Quaternion initialR;
  void LateUpdate()
    {
        transform.position = PL.transform.position + offset;
        transform.rotation = initialR;
    }
}
