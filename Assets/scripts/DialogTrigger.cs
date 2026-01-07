using System.Collections;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject dialog;
    [SerializeField] private int waitBeforeCloseDialog = 5;
    
    private Coroutine _closeCoroutine;
    
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            dialog.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (!trigger.CompareTag("Player")) return;

        if (_closeCoroutine != null)
            StopCoroutine(_closeCoroutine);

        _closeCoroutine = StartCoroutine(CloseDialog());
        gameObject.SetActive(false);
    }

    
    private IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(waitBeforeCloseDialog);
        dialog.SetActive(false);
    }
}
