using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonQuitLevel : MonoBehaviour
{
   
   [SerializeField] private AudioSource musicLevel;
   
   public void QuitLevel()
   {
      musicLevel.Stop();
      SceneManager.LoadScene("Home");
   }
}
