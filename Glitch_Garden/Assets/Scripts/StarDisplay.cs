using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 40;
    TextMeshProUGUI starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateStarText();
    }

    public int Stars { get { return stars; } }

    private void UpdateStarText()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int starsToAdd)
    {
        stars += starsToAdd;
        UpdateStarText();
    }

    public void SpendStars(int starsToSpend)
    {
        if (starsToSpend <= stars)
        {
            AddStars(-starsToSpend);
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return amount <= stars;
    }
}
