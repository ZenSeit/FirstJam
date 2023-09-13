using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArtifacts : MonoBehaviour
{
    int artifactsCollected = 0;
    public int artifactsToCollect = 3;

    public void CollectArtifact()
    {
        artifactsCollected++;
        if (artifactsCollected >= artifactsToCollect)
        {
            Debug.Log("You win!");
        }
    }


}
