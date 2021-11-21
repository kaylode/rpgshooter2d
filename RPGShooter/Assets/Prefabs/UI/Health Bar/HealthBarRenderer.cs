using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBarRenderer : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public Damageable target;
    public Canvas canvas;
    private Slider slider;

    private GameObject healthBar;

    private void Start()
    {
        this.healthBar = Instantiate(healthBarPrefab, target.transform.position+Vector3.up*1.75f, target.transform.rotation);
        this.healthBar.transform.SetParent(canvas.transform);
        this.healthBar.transform.localScale = new Vector3(1.5f, 1, 1);

        slider = healthBar.GetComponent<Slider>();
        this.slider.minValue = 0;
        this.slider.maxValue = target.GetMaxHealth();
        this.slider.value = target.GetHealth();
    }

    private void Update()
    {
        float value = target.GetHealth();
        this.slider.value = Math.Max(value, this.slider.minValue);
        this.healthBar.transform.position = this.target.transform.position + Vector3.up * 1.75f;
    }

}
