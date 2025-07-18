using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health;

    private float originalWidth;

    // Start is called before the first frame update
    void Start()
    {
        originalWidth = mask.sizeDelta.x;
        UpdateHealthValue();
        health.onHealthChanged += UpdateHealthValue;
    }
    private void UpdateHealthValue()
    {
        float scale = (float)health.currentHp() / health.maxHp();
        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }

}
