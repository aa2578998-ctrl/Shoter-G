using UnityEngine.UI;
using UnityEngine;

using System;

public class HP_Slider_Boss : MonoBehaviour
{
    [Range(0.00f, 1.00f)]
    public float currentHP = 1f;
    public HP_Slider_Boss initite;
    public Animation_Death_Boss Death_Boss;
    public HP_Slider_Boss slider_Boss_HP;
    public Slider_Movement_Spawn Movement_Slider;
    private RectTransform rectTransform;
    public Transform Boss;
    public Transform Sliders;
    public Vector3 ScalesSlider = new Vector3(0f, 0f, 0f);
    public Vector3 ScalesSliderBuldge = new Vector3(0f, 0f, 0f);
    public Slider slider;

    public bool Times = false;
    float timeCurrent = 0;
    void Start()
    {
        initite = GetComponent<HP_Slider_Boss>();

        initite.enabled = false;

        rectTransform = GetComponent<RectTransform>();
        Death_Boss = FindAnyObjectByType<Animation_Death_Boss>();
        slider_Boss_HP = FindAnyObjectByType<HP_Slider_Boss>();
        Movement_Slider = FindAnyObjectByType<Slider_Movement_Spawn>();
    }

    void LateUpdate()
    {

        SetHPslider(currentHP);
        if (currentHP <= 0f)
        {
            Death_Boss.ActivatedDeath();
            slider_Boss_HP.enabled = false;

            Movement_Slider.SpawnMove = false;
            Movement_Slider.DeadMove = true;
        }
        else if (currentHP > 0f)
        {
            Movement_Slider.SpawnMove = true;
            Movement_Slider.DeadMove = false;
        }

    }
    public void SetHPslider(float HPboss)
    {
        HPboss = Mathf.Clamp01(HPboss);
        rectTransform.localScale = new Vector3(HPboss, rectTransform.localScale.y, rectTransform.localScale.z);

        Sliders.localScale = ScalesSlider;
        if (Times)
        {
            timeCurrent += Time.deltaTime;
            if (timeCurrent >= 1.5f)
            {
                Sliders.localScale = ScalesSliderBuldge;
                Times = false;
            }
        }
    }
}
