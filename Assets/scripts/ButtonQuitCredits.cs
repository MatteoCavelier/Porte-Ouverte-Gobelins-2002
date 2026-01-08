using UnityEngine;

public class ButtonQuitCredits : MonoBehaviour
{
    [SerializeField] private GameObject creditsMenu;
    
    public void CloseCredits()
    {
        creditsMenu.SetActive(false);
    }
}
