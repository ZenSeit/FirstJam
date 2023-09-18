using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform currentCheckpoint;
    public GameObject playerPrefab;
    private GameObject playerInstance;

    private AudioManager audioManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    private void Start()
    {
        //SpawnPlayer();
        playerInstance = FindObjectOfType<PlayerMovement>().gameObject;
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
        playerInstance.transform.position = currentCheckpoint.position;
        audioManager.PlaySFXSound(audioManager.dieSound);
    }

    [ContextMenu("Game Over")]
    public void GameOver()
    {
        currentCheckpoint= Instance.transform;
        SpawnPlayer();

    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void YouWin()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

