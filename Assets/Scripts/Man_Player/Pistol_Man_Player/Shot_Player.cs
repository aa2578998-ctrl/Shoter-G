using UnityEngine;
using UnityEngine.InputSystem;
public class Shot_Player : MonoBehaviour
{
    public GameObject Projectile;

    public float TimeS;

    public float corrutineTime;

    private bool startCTime = false;

    public float Spatrons;

    public float Patron;

    public TMP_HP_Player tMP_HP_Player;

    void Start()
    {
        Spatrons = Patron;
        corrutineTime = TimeS;
    }

    void LateUpdate()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Spatrons > 0f)
        {
            Instantiate(Projectile, transform.position, transform.rotation);

            Spatrons -= 1f;
        }
        else if (Spatrons <= 0f)
        {
            startCTime = true;
            if (startCTime)
            {
                corrutineTime -= Time.deltaTime;

                if (corrutineTime <= 0f)
                {
                    Spatrons = Patron;
                    corrutineTime = TimeS;
                }
            }
            tMP_HP_Player.CooldownShot();
        }
        tMP_HP_Player.QuanityPatron();
    }
}
