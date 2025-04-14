using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    private void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        // Toggle pause when pressing Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Pauses the game and shows the pause menu
    public void PauseGame()
    {
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f; // Freeze the game (pause)
    }

    // Resumes the game and hides the pause menu
    public void ResumeGame()
    {
        AudioListener.pause = false;
        isPaused = false;
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        Time.timeScale = 1f; // Resume the game (unpause)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Example of quitting the game
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}