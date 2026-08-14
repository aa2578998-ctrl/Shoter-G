using UnityEngine;

public class Area_Attack_2_Boss : MonoBehaviour
{
    public GameObject Player;
    public float Time1;
    public float HightOffset;
    public float Time2;
    public float StaticTime;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, HightOffset, Player.transform.position.z);
            if (Time1 >= StaticTime)
            {
                GetComponent<Renderer>().enabled = false;
                Time2 += Time.deltaTime;
                if (Time2 >= StaticTime)
                    Time1 = 0f;
            }
            if (Time2 >= StaticTime)
            {
                GetComponent<Renderer>().enabled = true;
                Time1 += Time.deltaTime;
                if (Time1 >= StaticTime)
                    Time2 = 0f;
            }
    }
}
