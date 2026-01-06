using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool playerCanMove = true;
    public static GameManager Instance;
    
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
}
