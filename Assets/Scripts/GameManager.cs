using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool player1Reached = false;
    private bool player2Reached = false;

    void Awake()
    {
        instance = this;
    }

    // CALL when player reaches endpoint
    public void PlayerReachedEndpoint(string playerTag)
    {
        if (playerTag == "Player1")
        {
            player1Reached = true;
        }
        else if (playerTag == "Player2")
        {
            player2Reached = true;
        }

        Debug.Log("Player reached endpoint: " + playerTag);

        // ONLY when BOTH players reach
        if (player1Reached && player2Reached)
        {
            LoadGameOverScene();
        }
    }

    // CALL when any player loses all lives
    public void PlayerLost()
    {
        Debug.Log("Player Lost All Lives");

        Time.timeScale = 0f;

        SceneManager.LoadScene("LostGame");
    }

    // Loads GameOver scene when BOTH win
    void LoadGameOverScene()
    {
        Debug.Log("Both Players Won");

        Time.timeScale = 0f;

        SceneManager.LoadScene("EscapeScene");
    }
}
