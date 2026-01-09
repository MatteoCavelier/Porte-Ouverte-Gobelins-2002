using System.Collections;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject globalLight;
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private GameObject quitLevelMenu;
    [SerializeField] private GameObject CV;
    
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            globalLight.SetActive(true);
            levelMusic.Stop();
            StartCoroutine(QuitLevel());
        }
    }

    private IEnumerator QuitLevel()
    {
        yield return new WaitForSeconds(10);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CV.SetActive(false);
        quitLevelMenu.SetActive(true);
    }
}
