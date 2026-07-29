using UnityEngine;
using UnityEngine.InputSystem;
public class Rotare_Player : MonoBehaviour
{
    public float speedR;

    public float LeftR = -50f;

    public float RightR = 50f;

    public float CurrentR = 0f;

    public InputAction action;

    private Vector2 ActR;

   void Start()
    {
        action.Enable();
    }
 void LateUpdate()
    {
        float input = ActR.x * speedR * Time.deltaTime;

        CurrentR += input;

        CurrentR = Mathf.Clamp(CurrentR, LeftR, RightR);

        transform.localRotation = Quaternion.Euler(-90f, CurrentR, 0f);

        transform.Rotate(Vector3.down * speedR * Time.deltaTime * ActR.x);

        ActR = action.ReadValue<Vector2>();
    }
}
