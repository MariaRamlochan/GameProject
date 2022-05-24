using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    public int health = 30;
    public int damage = 10;
    public Image filler;

    // Use this for initialization
    void Start()
    {
        filler.fillAmount = 1.0f;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health = health - damage;
            filler.fillAmount -= 1.0f/3.0f;
            Debug.Log(health);

        }

        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
