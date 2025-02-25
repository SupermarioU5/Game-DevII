using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenuUI;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Begin()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false; // Stop the game in the Unity editor
        }
        else
        {
            Application.Quit(); // Quit the application when built
        }
            
    }
}
