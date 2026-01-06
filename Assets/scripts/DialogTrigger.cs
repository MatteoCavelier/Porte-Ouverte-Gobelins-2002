using System.Collections;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject dialog;
    [SerializeField] private int waitBeforeCloseDialog = 5;
    
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            dialog.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CloseDialog());
        }
    }
    
    private IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(waitBeforeCloseDialog);
        dialog.SetActive(false);
    }
}
