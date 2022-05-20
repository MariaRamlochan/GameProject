using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public int health = 30;
    public int damage = 10;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health = health - damage;
            Debug.Log(health);

        }

        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
