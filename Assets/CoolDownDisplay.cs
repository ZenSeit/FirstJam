using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField] private Image cooldownImage;
    [SerializeField] private PlayerChangeSize playerChangeSize;

    private void OnEnable()
    {
        // Subscribe to the ChangeSizeActivated event
        playerChangeSize.ChangeSizeActivated += HandleChangeSizeActivated;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to avoid memory leaks
        playerChangeSize.ChangeSizeActivated -= HandleChangeSizeActivated;
    }

    private void HandleChangeSizeActivated(float changeSizeDuration)
    {
        // Calculate the fill amount based on the cooldown duration
        float cooldownTime = changeSizeDuration;
        StartCoroutine(StartCooldown(cooldownTime));
    }

    private IEnumerator StartCooldown(float cooldownTime)
    {
        float currentTime = 0f;

        while (currentTime < cooldownTime)
        {
            currentTime += Time.deltaTime;
            float fillAmount = currentTime / cooldownTime;
            cooldownImage.fillAmount = fillAmount;
            yield return null;
        }

        cooldownImage.fillAmount = 0f; // Reset the fill amount when the cooldown is complete
    }
}
