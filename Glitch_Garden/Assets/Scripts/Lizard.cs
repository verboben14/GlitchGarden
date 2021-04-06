using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        Defender defender = otherObject.GetComponent<Defender>();
        if (defender != null)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
