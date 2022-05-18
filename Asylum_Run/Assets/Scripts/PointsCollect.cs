using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCollect : MonoBehaviour
{
    [SerializeField]
    public int score = 0;
    public int total = 0;
    public TMP_Text lblScore;
    public AudioSource audioScorce;
    public AudioClip syringeAudio;
    public AudioClip keyAudio;

    private void Start()
    {
        audioScorce = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Syringe")
        {
            score += 1;
            lblScore.text = "Score: " + score;
            audioScorce.PlayOneShot(syringeAudio);
        }

        if (other.gameObject.tag == "Key")
        {
            score = 0;
            score += 1;
            lblScore.text = "Keys: " + score + "/" + total;
            audioScorce.PlayOneShot(keyAudio);
        }
    }
}
