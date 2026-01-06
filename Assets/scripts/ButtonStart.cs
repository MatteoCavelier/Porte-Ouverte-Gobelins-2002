using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public void NavigateToLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
