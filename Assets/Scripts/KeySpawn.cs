using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform spawnPoint;
    public int maxPoints;
    public bool isSpawn = false;

    private int score;

    // Update is called once per frame
    void Update()
    {
        score = gameObject.GetComponent<Points>().score;
        if (score == maxPoints)
        {
            if (isSpawn == false)
            {
                Instantiate(keyPrefab, spawnPoint.position, Quaternion.Euler(90, 0, 0));
                isSpawn = true;
            }
        }
    }
}
