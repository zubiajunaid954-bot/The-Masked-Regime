using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pebble : MonoBehaviour
{
    public GameObject yellowPanel; // drag your yellow UI panel here
    private Image yellowImage;

    private int yellowFlashCounter = 0;
    private int maxYellowFlashes = 3;
    public float flashDuration = 0.5f; // total time of one flash

    // --- New sound variables ---
    public AudioClip collisionSound; // assign your sound in inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize yellow panel
        if (yellowPanel != null)
        {
            yellowPanel.SetActive(true);
            yellowImage = yellowPanel.GetComponent<Image>();
            if (yellowImage != null)
                yellowImage.color = new Color(1, 1, 0, 0); // fully transparent
            yellowPanel.SetActive(false);
        }

        // Initialize audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            // --- Play collision sound ---
           if (collisionSound != null)
                audioSource.PlayOneShot(collisionSound);

            // Rewind position
            PlayerRewind rewind = other.GetComponent<PlayerRewind>();
            if (rewind != null)
                rewind.Rewind();

            // Lose life
            PlayerLives lives = other.GetComponent<PlayerLives>();
            if (lives != null)
                lives.LoseLife();

            // Yellow flash effect
            if (yellowImage != null && yellowFlashCounter < maxYellowFlashes)
            {
                yellowFlashCounter++;
                StartCoroutine(FlashYellowSmooth());
            }
        }
    }

    private IEnumerator FlashYellowSmooth()
    {
        yellowPanel.SetActive(true);

        float halfDuration = flashDuration / 2f;
        float timer = 0f;

        // Fade in
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 0.5f, timer / halfDuration);
            yellowImage.color = new Color(1, 1, 0, alpha);
            yield return null;
        }

        timer = 0f;

        // Fade out
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0.5f, 0, timer / halfDuration);
            yellowImage.color = new Color(1, 1, 0, alpha);
            yield return null;
        }

        yellowPanel.SetActive(false);
    }
}
