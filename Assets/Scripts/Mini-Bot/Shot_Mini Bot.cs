using UnityEngine;
public class Shot_MiniBot : MonoBehaviour
{
    // Система отвечающая за контроль активности стрельбы
    public bool Patron = true;
    // Система отвечающая за перезарядку боеприпасов
    public bool Spatron = false;
    // Система отвечающая за контроль активности реагирования и работа способностью: Trigger, Patron
    public bool StartS = true;
    // Система отвечающая за контроль активацией Patron
    public bool Trigger;
    // Система отвечающая за контроль одноразового активации таймера
    public bool IsActives = false;
    // 
    public LayerMask Player;
    // 
    public GameObject Projectile;
    // 
    public float amountPatrons;
    // 
    public float amountSP = 0f;
    // 
    public float Stime = 0f;
    // 
    public float corrutineTime = 0f;
    // 
    public float attackTime = 0.2f;
    // 
    public float SattackTime = 0f;
    // 
    public float disL = 1.1f;
    // 
    public float MAXRangeATC = 0.6f;
    // 
    public float MINRangeATC = 0.2f;
    // 
    public Vector3 offs = new Vector3(0, 0, 0);
    // 
    void Start()
    {// 
        amountPatrons = amountSP;
        // 
        attackTime = (float)System.Math.Round(Random.Range(MINRangeATC, MAXRangeATC), 1);
    }
    // 
    void LateUpdate()
    {// 
        if (StartS)
        {// 
            Quaternion offsetR = Quaternion.Euler(offs);
            // 
            Vector3 rayDir = transform.rotation * (offsetR * Vector3.forward);
            // 
            Trigger = Physics.Raycast(transform.position, rayDir, disL, Player);
            // 
            if (Trigger)
            {
                // 
                Patron = true;
            }
            // 
            else
            {// 
                Patron = false;
            }
            //
            if (Patron)
            {//
                if (SattackTime <= 0f)
                {// 
                    Instantiate(Projectile, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                    // 
                    amountPatrons -= 1f;
                    // 
                    SattackTime = attackTime;
                }
                // 
                else
                {
                    //   
                    SattackTime -= Time.deltaTime;
                }
            }
        }
        //
        if (amountPatrons <= 0f && !IsActives)
        { //
            corrutineTime = Stime;
            //
            StartS = false;
            // 
            Spatron = true;
            // 
            IsActives = true;
        }
        // 
        if (Spatron)
        {// 
            corrutineTime -= Time.deltaTime;
            // 
            if (corrutineTime <= 0f)
            {//
                amountPatrons = amountSP;
                // 
                corrutineTime = 0f;
                // 
                StartS = true;
                // 
                Spatron = false;
                // 
                IsActives = false;
            }
        }
    }//
    private void OnDrawGizmosSelected()
    {//
        Quaternion offsetr = Quaternion.Euler(offs);
        // 
        Vector3 rayDir = transform.rotation * (offsetr * Vector3.forward);
        // 
        if (Application.isPlaying && Trigger)
        {// 
            Gizmos.color = Color.green;
        }
        // 
        else
        // 
        { Gizmos.color = Color.red; }
        // 
        Gizmos.DrawLine(transform.position, transform.position + rayDir * disL);
    }
}
