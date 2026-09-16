using UnityEngine;
using UnityEngine.InputSystem;
public class Dash_Player2 : MonoBehaviour
{
    public float Distance;
    public float cooldownE;
    public float cooldown = 2f;
    private bool InputD = true;

    public TMP_HP_Player tMP_HP_Player;

    void LateUpdate()
    {
        if (InputD && Keyboard.current.iKey.wasPressedThisFrame)
        {
            transform.Translate(Vector3.right * Distance * Time.deltaTime);
            InputD = false;
            cooldownE = cooldown;
        }
        if (cooldownE > 0f)
        {
            cooldownE -= Time.deltaTime;
        }
        else if (cooldownE <= 0f)
        {
            cooldownE = 0f;
            InputD = true;
        }

        tMP_HP_Player.CooldownDash();
    }
}
