using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObstacleDamage : MonoBehaviour
{
    public GameObject redPanel; // Drag your UI panel here
    private Image redImage;

    private int redFlashCounter = 0;
    private int maxRedFlashes = 3;
    public float flashDuration = 0.5f; // total time of one flash

    // --- New Sound Variables ---
    public AudioClip collisionSound; // assign in inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize red panel
        if (redPanel != null)
        {
            redPanel.SetActive(true); // must be active to get Image
            redImage = redPanel.GetComponent<Image>();
            if (redImage != null)
                redImage.color = new Color(1, 0, 0, 0); // fully transparent
            redPanel.SetActive(false);
        }

        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            // --- Play collision sound ---
            if (collisionSound != null)
                audioSource.PlayOneShot(collisionSound);

            // Lose life
            PlayerLives player = other.GetComponentInParent<PlayerLives>();
            if (player != null)
                player.LoseLife();

            // Show red flash
            if (redImage != null && redFlashCounter < maxRedFlashes)
            {
                redFlashCounter++;
                StartCoroutine(FlashRedSmooth());
            }
        }
    }

    private IEnumerator FlashRedSmooth()
    {
        redPanel.SetActive(true);

        float halfDuration = flashDuration / 2f;
        float timer = 0f;

        // Fade in
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 0.5f, timer / halfDuration);
            redImage.color = new Color(1, 0, 0, alpha);
            yield return null;
        }

        timer = 0f;

        // Fade out
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0.5f, 0, timer / halfDuration);
            redImage.color = new Color(1, 0, 0, alpha);
            yield return null;
        }

        redPanel.SetActive(false);
    }
}
