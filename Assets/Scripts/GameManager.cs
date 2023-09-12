using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform currentCheckpoint;
    public GameObject playerPrefab;
    private GameObject playerInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }
    
    public void UpdateCheckPoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void SpawnPlayer()
    {
        if (playerInstance != null)
        {
            Destroy(playerInstance);
        }

        playerInstance = Instantiate(playerPrefab, currentCheckpoint.position, currentCheckpoint.rotation);
    }

    [ContextMenu("Player Died")]
    public void PlayerDied()
    {
        // logic for the player dying
        SpawnPlayer();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K)) 
        {
            PlayerDied();
        }
    }
}

