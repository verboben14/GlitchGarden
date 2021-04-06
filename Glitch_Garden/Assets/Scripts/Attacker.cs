using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>()?.IncreaseEnemyCount();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>()?.DecreaseEnemyCount();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (currentTarget == null)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget == null)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health != null)
        {
            health.DealDamage(damage);
        }
    }
}
