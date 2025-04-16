using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void Menu()
    {
        if (SpeedrunTimer.instance != null)
        {
            Destroy(SpeedrunTimer.instance.gameObject);
        }
            SceneManager.LoadScene("MainMenu");
    }
}
