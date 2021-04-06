using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 3f;
    [SerializeField] float maxSpawnDelay = 6f;
    [SerializeField] Attacker[] attackerPrefabs;
    bool isSpawning = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnRandomAttacker();
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void SpawnRandomAttacker()
    {
        Spawn(attackerPrefabs[Random.Range(0, attackerPrefabs.Length)]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
