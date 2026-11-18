
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text titleText;

    // Called when Play button is clicked
    public void PlayGame()
    {
        Debug.Log("Starting Game...");
        SceneManager.LoadScene("GamePlay");
    }

    // Called when Quit button is clicked
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");

        Application.Quit();
    }

    // Optional: Display a welcome message
    private void Start()
    {
        if (titleText != null)
        {
            titleText.text = "Rock Paper Scissors";
        }
    }
}
