using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject keyToPress;
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private float openDoorTime = 1f;
    
    private bool _isDoorOpen;
    private bool _isInTrigger;
    
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            keyToPress.SetActive(true);
            _isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            keyToPress.SetActive(false);
            _isInTrigger = false;
        }
    }

    private void Update()
    {
        if (_isInTrigger)
        {
            if (Keyboard.current.eKey.isPressed)
            {
                keyToPress.SetActive(false);
                if (!_isDoorOpen)
                {
                    OpenDoor();
                }
            }
        }
        
        keyToPress.transform.LookAt(cam.transform);
    }

    private void OpenDoor()
    {
        keyToPress.transform.position = new Vector3(1000,1000,1000);
        door1.transform.DORotate(new Vector3(0,door1.transform.rotation.y - 90,0), openDoorTime, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCubic);
        door2.transform.DORotate(new Vector3(0,door2.transform.rotation.y + 90,0), openDoorTime, RotateMode.WorldAxisAdd).SetEase(Ease.InOutCubic);
        _isDoorOpen = true;
    }
}