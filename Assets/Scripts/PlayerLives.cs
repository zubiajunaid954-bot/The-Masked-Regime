using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerLives : MonoBehaviour
{
    public int maxLives; // we will set dynamically
    public int currentLives;

    public Image[] hearts;

    public string playerName;

    private HashSet<GameObject> obstaclesHit = new HashSet<GameObject>();

    void Start()
    {
        maxLives = hearts.Length; // match the number of hearts in UI
        currentLives = maxLives;
        UpdateHearts();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obstacleRoot = collision.gameObject.transform.root.gameObject;

        if (obstacleRoot.CompareTag("Obstacle") && !obstaclesHit.Contains(obstacleRoot))
        {
            LoseLife();
            obstaclesHit.Add(obstacleRoot);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject obstacleRoot = collision.gameObject.transform.root.gameObject;

        if (obstacleRoot.CompareTag("Obstacle"))
        {
            obstaclesHit.Remove(obstacleRoot);
        }
    }

    public void LoseLife()
    {
        if (currentLives <= 0) return;

        currentLives--;
        UpdateHearts();

        if (currentLives <= 0)
        {
            GameManager.instance.PlayerLost();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }
}
