using UnityEngine;

public class Endpoint : MonoBehaviour
{
    // --- New Sound Variables ---
    public AudioClip endpointSound; // assign in Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // --- Play sound ---
            if (endpointSound != null)
                audioSource.PlayOneShot(endpointSound);

            // Call GameManager
            GameManager.instance.PlayerReachedEndpoint(other.tag);
        }
    }
}
