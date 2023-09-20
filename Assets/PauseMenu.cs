using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private InputAction pause;
    private bool isPaused = false;

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject playerHUD;

    public PlayerMovement playerMovement;
    public PlayerChangeSize playerChangeSize;
    private void Start()
    {
        playerControls = new PlayerInputActions();
        pause = playerControls.UI.Pause;
        pause.Enable();
    }
    private void Update()
    {
        if (pause.WasPressedThisFrame())
        {
            DisplayPause();
        }
    }

    public void DisplayPause()
    {
        if (!isPaused) 
        {
            isPaused = true;
            pausePanel.SetActive(true);
            playerHUD.SetActive(false);
            playerChangeSize.enabled = false;
            playerMovement.enabled = false;
            SetTimeScale(0f);
        }
        else
        {
            isPaused = false;
            pausePanel.SetActive(false);
            optionsPanel.SetActive(false);
            playerHUD.SetActive(true);
            playerChangeSize.enabled = true;
            playerMovement.enabled = true;
            SetTimeScale(1f);
        }
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

}
