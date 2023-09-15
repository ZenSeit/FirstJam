using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectArtifacts : MonoBehaviour
{
    int artifactsCollected = 0;
    public int artifactsToCollect = 3;
    public TextMeshProUGUI artifactsText; // Reference to the TextMeshPro object

    public void CollectArtifact()
    {
        artifactsCollected++;
        if (artifactsCollected >= artifactsToCollect)
        {
            Debug.Log("You win!");
        }
        ChangeItemsHUD();
    }

    public void ChangeItemsHUD()
    {
        artifactsText.text = artifactsCollected.ToString() + "/" + artifactsToCollect.ToString();
    }

}
