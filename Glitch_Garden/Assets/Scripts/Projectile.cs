using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damage = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();
        Health attackerHealth = other.GetComponent<Health>();
        if (attacker != null && attackerHealth != null)
        {
            attackerHealth.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
