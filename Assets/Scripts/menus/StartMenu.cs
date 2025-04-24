using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenuUI;
    public GameObject leaderboardUI;
    void Start()
    {
         leaderboardUI.SetActive(false);
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
        Application.Quit(); // Quit the application when built
    }
    public void SpeedrunStart()
    {
        // Load the scene asynchronously and then start the timer
        SceneManager.sceneLoaded += OnGameSceneLoaded;
        SceneManager.LoadScene("GameScene");
    }
    private void OnGameSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Instantiate the timer prefab
        GameObject timerObject = Instantiate(Resources.Load<GameObject>("SpeedrunTimer"));

        // Start the timer
        SpeedrunTimer timer = timerObject.GetComponent<SpeedrunTimer>();
        timer.StartTimer();

        // Unsubscribe to prevent duplicate calls
        SceneManager.sceneLoaded -= OnGameSceneLoaded;
    }
    public void LeaderboardOpen()
    {
        mainMenuUI.SetActive(false);
        leaderboardUI.SetActive(true);
    }
    public void LeaderboardClose()
    {
        mainMenuUI.SetActive(true);
        leaderboardUI.SetActive(false);
    }
}
