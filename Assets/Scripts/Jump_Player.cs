using UnityEngine;
using UnityEngine.InputSystem;
public class Jump_Player : MonoBehaviour
{
    public float disLayer = 1.1f;
    public float jumpSpeed;
    public float jumpGravity;
    public float jumpHight;
    private Rigidbody Rb;
    public LayerMask surface;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
  void LateUpdate()
    {
        bool Ground = Physics.Raycast(transform.position, Vector3.down, disLayer, surface);
        if (Keyboard.current != null && Keyboard.current.yKey.wasPressedThisFrame && Ground)
        {
            Rb.linearVelocity = new Vector3(Rb.linearVelocity.x, jumpHight, Rb.linearVelocity.z);
            if (Rb.linearVelocity.y < 0f)
            {

            }
        }
    }
}
