using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    const string VFX_PARENT_NAME = "VisualEffects";

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathEffectPrefab;
    [SerializeField] float delayDeathEffectDestroy = 2f;
    GameObject vfxParent;

    private void Start()
    {
        CreateVFXParent();
    }

    private void CreateVFXParent()
    {
        vfxParent = GameObject.Find(VFX_PARENT_NAME);
        if (vfxParent == null)
        {
            vfxParent = new GameObject(VFX_PARENT_NAME);
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (deathEffectPrefab == null)
        {
            return;
        }
        GameObject deathEffectObject = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity, vfxParent.transform);
        Destroy(deathEffectObject, delayDeathEffectDestroy);
    }
}
