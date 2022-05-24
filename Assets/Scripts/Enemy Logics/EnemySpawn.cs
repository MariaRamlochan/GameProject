using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public bool isSpawn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isSpawn == false)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.Euler(90, 0, 0));
                isSpawn = true;
            }
        }
    }
}
