using UnityEngine;
using UnityEngine.InputSystem;
public class Controller_Player : MonoBehaviour
{
    public float speed;
    public float speedRotate;
    public Vector2 Controll;
    public InputAction Input;
  void Start()
    {
        Input.Enable();
    }
void LateUpdate()
    {
        transform.Translate(Vector3.right *  speed * Time.deltaTime * Controll.y);
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime * Controll.x);
        Controll = Input.ReadValue<Vector2>();
    }
}
