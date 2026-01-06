using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{

    [SerializeField] private GameObject keyToPress;
    [SerializeField] private GameObject dialog;
    
    private void OnTriggerEnter(Collider trigger)
    {
        keyToPress.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        keyToPress.SetActive(false);    
        dialog.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {
            keyToPress.SetActive(false);
            dialog.SetActive(true);
        }
    }
}
