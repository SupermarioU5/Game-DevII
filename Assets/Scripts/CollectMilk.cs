using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectMilk : MonoBehaviour
{
    public GameObject milk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SpeedrunTimer.instance != null)
            {
                SpeedrunTimer.instance.StopTimer();
                TextMeshProUGUI timerText = SpeedrunTimer.instance.GetComponentInChildren<TextMeshProUGUI>();
                if (timerText != null)
                {
                    RectTransform rect = timerText.GetComponent<RectTransform>();
                    Vector3 newPosition = rect.localPosition;
                    newPosition.y += -273;
                    newPosition.x += -20;
                    rect.localPosition = newPosition;
                    rect.localScale = new Vector2(4f, 4f);
                }
            }
            SceneManager.LoadScene("TheEnd");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(milk);
        }
    }
}
