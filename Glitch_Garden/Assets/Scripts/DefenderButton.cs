using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (costText == null)
        {
            Debug.LogError(name + " has no cost text. Add one please!");
        }
        else
        {
            costText.text = defenderPrefab.StarCost.ToString();
        }
    }

    private void OnMouseDown()
    {
        var defenderButtons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton defenderButton in defenderButtons)
        {
            SpriteRenderer spriteRenderer = defenderButton.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color32(41, 41, 41, 255);
        }
        this.GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
