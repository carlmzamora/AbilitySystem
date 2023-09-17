using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    [SerializeField] private Image bar;

    private void Update()
    {
        bar.fillAmount = healthController.CurrentHealth / healthController.MaxHealth;
    }
}
