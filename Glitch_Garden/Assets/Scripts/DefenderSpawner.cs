using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";

    Defender defender;
    GameObject defenderParent;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (defenderParent == null)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if (defender != null)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnCoordinates)
    {
        Instantiate(defender, spawnCoordinates, Quaternion.identity, defenderParent.transform);
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        this.defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 spawnCoordinates)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.StarCost;
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(spawnCoordinates);
            starDisplay.SpendStars(defender.StarCost);
        }
    }
}
