using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        Gravestone gravestone = otherObject.GetComponent<Gravestone>();
        if (gravestone != null)
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
            return;
        }
        Defender defender = otherObject.GetComponent<Defender>();
        if (defender != null)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
