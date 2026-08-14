using UnityEngine.UI;
using UnityEngine;

public class HP_Slider_Player : MonoBehaviour
{
    [Range(0f, 100f)]
    public float currentHP = 100f;
    private RectTransform rectTransform;

    public Slider slider;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        SetHPslider(currentHP);
    }

    public void SetHPslider(float HPboss)
    {
        HPboss = Mathf.Clamp01(HPboss);
        rectTransform.localScale = new Vector3(HPboss, rectTransform.localScale.y, rectTransform.localScale.z);
    }

    public void SetMaxHP(float HPboss)
    {
        slider.maxValue = HPboss;
        slider.value = HPboss;
    }

    public void SetHPBoss(float HPboss)
    {
        slider.value = HPboss;
    }
}
