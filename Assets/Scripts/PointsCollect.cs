using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointsCollect : MonoBehaviour
{
    [SerializeField]
    public int score = 0;
    public int totalKey = 0;
    public TMP_Text lblScore;
    public AudioSource audioScorce;
    public AudioClip syringeAudio;
    public AudioClip keyAudio;
    public Image icon;
    public Sprite syringSprite;
    public Sprite keySprite;

    private void Start()
    {
        audioScorce = GetComponent<AudioSource>();
        icon.sprite = syringSprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Syringe")
        {
            score += 1;
            lblScore.text = "X " + score;
            audioScorce.PlayOneShot(syringeAudio);
        }

        if (other.gameObject.tag == "Key")
        {
            score = 0;
            score += 1;
            icon.sprite = keySprite;
            lblScore.text = score + "/" + totalKey;
            audioScorce.PlayOneShot(keyAudio);
        }

        if (other.gameObject.tag == "Exit")
        {
            if (score == totalKey)
            {
                SceneManager.LoadScene("FinalLevel");
            }
        }
    }
}
