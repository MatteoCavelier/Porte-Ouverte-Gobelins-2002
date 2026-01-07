using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCredits : MonoBehaviour
{
    public void NavigateToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
