using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro UseText;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    public AudioSource audioScorce;
    public AudioClip doorOpenAudio;
    public AudioClip doorCloseAudio;

    private void Start()
    {
        audioScorce = GetComponent<AudioSource>();
    }

    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if(door.IsOpen){
                    door.Close();
                    audioScorce.PlayOneShot(doorCloseAudio);
                }
                else
                {
                    door.Open(transform.position);
                    audioScorce.PlayOneShot(doorOpenAudio);
                }
            }
        }
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers)
            && hit.collider.TryGetComponent<Door>(out Door door))
        {
            if (door.IsOpen)
            {
                UseText.SetText("Close \"E\"");
            }
            else
            {
                UseText.SetText("Open \"E\"");
            }
            UseText.gameObject.SetActive(true);
            UseText.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.50f;
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
        }
        else
        {
            UseText.gameObject.SetActive(false);
        }
    }
}

