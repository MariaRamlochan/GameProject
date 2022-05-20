using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
   public int count = 0;
   private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            count += 1;
        }

        if (count == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
