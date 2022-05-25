using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyCollision : MonoBehaviour
{
    public int health = 3;
    public int damage = 1;
    public Image filler;
    public TMP_Text lblHealthAmount;

    public float knockBackForce = 250;

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
            lblHealthAmount.text = "X " + health;
            Debug.Log(health);
            knockBack();
        }

        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void knockBack()
    {
        transform.position += transform.forward * Time.deltaTime * knockBackForce;
    }
}
