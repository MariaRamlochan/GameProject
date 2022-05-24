using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool isSpawn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isSpawn == false)
            {
                enemyPrefab.SetActive(true);
                isSpawn = true;
            }
        }
    }
}
