using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button buttonResume;
    [SerializeField] private AudioSource musicLevel;

    public bool playerCanMove = true;
    public static GameManager Instance;
    private bool _timeIsPaused;
    
    void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void OnDestroy()
    {
        Time.timeScale = 1;
    }
    
    void Start()
    {
        buttonResume.onClick.AddListener(ResumeGame);
        musicLevel.Play();
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
