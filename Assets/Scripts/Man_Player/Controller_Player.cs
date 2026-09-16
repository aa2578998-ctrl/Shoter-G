using UnityEngine;
using UnityEngine.InputSystem;
public class Controller_Player : MonoBehaviour
{
    public int damage;
    public float speed;
    public float speedRotate;
    public Vector2 Controll;
    public InputAction Input;
    public TMP_HP_Player playerHP;

    void Start()
    {
        Input.Enable();
        playerHP = FindAnyObjectByType<TMP_HP_Player>();
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * Controll.y);
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime * Controll.x);
        Controll = Input.ReadValue<Vector2>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss_1"))
        {
            playerHP.TakeDamage(damage);
        }
    }
}
