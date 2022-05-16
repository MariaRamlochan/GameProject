using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField]
    public int score = 0;
    public TMP_Text lblScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Syringe")
        {
            score += 1;
            lblScore.text = "Score: " + score;
        }
    }
}
