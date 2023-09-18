using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectArtifacts : MonoBehaviour
{
    int artifactsCollected = 0;
    public int artifactsToCollect = 3;
    public TextMeshProUGUI artifactsText; // Reference to the TextMeshPro object
    [SerializeField] private LoadScene sceneManager;

    private AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void CollectArtifact()
    {
        artifactsCollected++;
        audioManager.PlaySFXSound(audioManager.coinSound);
        if (artifactsCollected >= artifactsToCollect)
        {
            sceneManager.Winner();
        }
        ChangeItemsHUD();
    }

    public void ChangeItemsHUD()
    {
        artifactsText.text = artifactsCollected.ToString() + "/" + artifactsToCollect.ToString();
    }

}
