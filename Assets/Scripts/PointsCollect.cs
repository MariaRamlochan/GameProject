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
    public TMP_Text lblTask;
    public AudioSource audioScorce;
    public AudioClip syringeAudio;
    public AudioClip keyAudio;
    public Image icon;
    public Sprite syringSprite;
    public Sprite keySprite;

    public GameObject keyPrefab;
    public Transform spawnPoint;
    public int maxPoints;
    public bool isSpawn = false;

    private void Start()
    {
        audioScorce = GetComponent<AudioSource>();
        icon.sprite = syringSprite;
        lblTask.text = "Avoid The Enemy\nCollect All Syringes";
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Syringe")
        {
            score += 1;
            lblScore.text = "X " + score;
            audioScorce.PlayOneShot(syringeAudio);
            if (score == maxPoints)
            {
                lblTask.text = "Find The Key";
                if (isSpawn == false)
                {
                    Instantiate(keyPrefab, spawnPoint.position, Quaternion.Euler(90, 0, 0));
                    isSpawn = true;
                }
            }
        }

        if (other.gameObject.tag == "Key")
        {
            score = 0;
            score += 1;
            icon.sprite = keySprite;
            lblScore.text = score + "/" + totalKey;
            lblTask.text = "Escape Through The Front Door";
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
