using UnityEngine;
using UnityEngine.SceneManagement;

public class LostGameUI : MonoBehaviour
{
    public void ResetSimulation()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LEVEL"); // your main gameplay scene
    }
}
