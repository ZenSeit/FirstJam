using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeSize : MonoBehaviour
{
    [SerializeField] private CharacterStatsScriptableObject characterStats;

    private PlayerInputActions playerControls;
    private InputAction changeSize;
    private float coolDownTimer;
    public event Action<float> ChangeSizeActivated;

    [Header("Animation")]
    private Animator animator;

    private AudioManager audioManager;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
   
    private void OnEnable()
    {
        changeSize = playerControls.Player.ChangeSize;
        changeSize.Enable();
    }

    private void OnDisable()
    {
        changeSize.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;
        if (changeSize.WasPressedThisFrame() && coolDownTimer < 0)
        {
            coolDownTimer = characterStats.changeSizeCoolDown;
            StartCoroutine("ChangeSize");
            audioManager.PlaySFXSound(audioManager.transformationSound);
            ChangeSizeActivated?.Invoke(characterStats.changeSizeDuration);
        }
        
    }

    IEnumerator ChangeSize()
    {
        Vector2 initialScale = transform.localScale;

        transform.localScale = new Vector2(1f* characterStats.mutiplierScale, 1f* characterStats.mutiplierScale);
        yield return new WaitForSeconds(characterStats.changeSizeDuration);
        transform.localScale = initialScale;
        animator.SetBool("TinyMode", true);
    }
}
