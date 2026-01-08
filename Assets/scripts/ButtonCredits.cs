using UnityEngine;

public class ButtonCredits : MonoBehaviour
{
    
    [SerializeField] private GameObject creditsMenu;
    
    public void NavigateToCredits()
    {
        creditsMenu.SetActive(true);
    }
}
