using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float baseHealth = 80f;
    float health;
    TextMeshProUGUI healthText;

    private void Start()
    {
        health = baseHealth / PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateHealth();
    }

    public void LoseHealth(int damage)
    {
        this.health = Mathf.Clamp(health - damage, 0, health);
        UpdateHealth();
        if (this.health <= 0)
        {
            FindObjectOfType<LevelController>().HandleLose();
        }
    }

    private void UpdateHealth()
    {
        healthText.text = Mathf.RoundToInt(health).ToString();
    }
}
