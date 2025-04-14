using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectMilk : MonoBehaviour
{
    public GameObject milk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("TheEnd");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(milk);
        }
    }
}
