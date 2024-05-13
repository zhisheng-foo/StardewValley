using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DayNightController : MonoBehaviour
{
    public Image panelImage;
    public float cycleDuration = 15f; // Duration for the complete cycle including maintenance
    public float transitionDuration = 5f; // Duration for the opacity change
    public float maintenanceDuration = 10f; // Duration to maintain current state before transitioning
    private float timer = 0;
    private bool isDay = true;

    void Start()
    {
        // Initialize the panel to be fully transparent (daytime)
        Color currentColor = panelImage.color;
        currentColor.a = 0f; // Fully transparent
        panelImage.color = currentColor;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // When the timer exceeds the total cycle duration, reset and toggle day/night
        if (timer > cycleDuration)
        {
            timer = 0;
            isDay = !isDay;
        }

        // Calculate the current opacity
        float alpha = panelImage.color.a;
        if (timer > maintenanceDuration) // Start transitioning after maintenance duration
        {
            if (isDay)
            {
                // Transition from day to night
                alpha = Mathf.Lerp(0f, 0.7f, (timer - maintenanceDuration) / transitionDuration);
            }
            else
            {
                // Transition from night to day
                alpha = Mathf.Lerp(0.7f, 0f, (timer - maintenanceDuration) / transitionDuration);
            }
        }
        else
        {
            // Maintain the current alpha during the maintenance period
            alpha = isDay ? 0f : 0.7f;
        }

        // Update the color with the new alpha value
        Color currentColor = panelImage.color;
        currentColor.a = alpha;
        panelImage.color = currentColor;
    }
}
