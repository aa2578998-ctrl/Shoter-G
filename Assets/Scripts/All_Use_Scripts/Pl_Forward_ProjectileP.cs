using UnityEngine;
public class PL_Forward_ProjectileP : MonoBehaviour
{
    public float speed; // 

    public float timeCorrutine; //

    public float scorees; //
    public TMP_Scorekills_Enemy score; //
    
    void Start()
    {
        score = FindAnyObjectByType<TMP_Scorekills_Enemy>(); // 
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //
        if (timeCorrutine > 0f ) //
        {
            timeCorrutine -= Time.deltaTime; //
        }    
        else //
        {
            Destroy(gameObject); //

            if (score != null) //
            {
                score.ScoreKills(scorees); //
            }
        }
    }
}
