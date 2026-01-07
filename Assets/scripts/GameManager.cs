using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject pauseMenu;

    public bool playerCanMove = true;
    public static GameManager Instance;
    private bool _timeIsPaused;
    
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (_timeIsPaused)
                ResumeGame();
            else
                PauseGame();
        }

    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        _timeIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _timeIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
