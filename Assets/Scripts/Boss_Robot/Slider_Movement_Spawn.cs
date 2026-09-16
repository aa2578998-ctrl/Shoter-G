using UnityEngine;

public class Slider_Movement_Spawn : MonoBehaviour
{
    public float speed;
    public RectTransform slider_HP_B;

    public Vector3 StartoffsetMove = new Vector3(0f, 0f, 0f);

    public Transform SliderOne;
    public Vector3 EndoffsetMove = new Vector3(0f, 0f, 0f);

    public bool SpawnMove = false;
    public bool DeadMove = false;

    void Start()
    {
        slider_HP_B = GetComponent<RectTransform>();
    }

    public void LateUpdate()
    {
        if (SpawnMove)
        {
            SliderOne.localPosition = Vector3.MoveTowards(slider_HP_B.localPosition, EndoffsetMove, speed * Time.deltaTime);
        }

        if (DeadMove)
        {
            SliderOne.localPosition = Vector3.MoveTowards(slider_HP_B.localPosition, StartoffsetMove, speed * Time.deltaTime);
        }
    }
}
