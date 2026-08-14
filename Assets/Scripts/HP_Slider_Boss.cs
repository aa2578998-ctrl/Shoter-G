using UnityEngine.UI;
using UnityEngine;

public class HP_Slider_Boss : MonoBehaviour
{
    [Range(0.00f, 1.00f)]
    public float currentHP = 1f;
    private RectTransform rectTransform;
    public Transform Sliders;
    public float ScalesSlider;
    public float ScalesSliderBuldge;
    public Slider slider;

    public bool Times = false;
    float timeCurrent = 0;
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
        Sliders.localScale = new Vector3(ScalesSlider, ScalesSlider, ScalesSlider);
        Times = true;
        if (Times)
        {
            timeCurrent += Time.deltaTime;
            if (timeCurrent >= 0.5f)
            {
                Sliders.localScale = new Vector3(ScalesSliderBuldge, ScalesSliderBuldge, ScalesSliderBuldge);
                Times = false;
            }
        }
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
