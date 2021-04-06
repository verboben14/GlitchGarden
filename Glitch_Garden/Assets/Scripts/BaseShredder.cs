using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<PlayerHealth>().LoseHealth(20);
        Destroy(other.gameObject);
    }
}
