using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject keyToPress;
    [SerializeField] private GameObject door;
    [SerializeField] private float openDoorTime = 2f;
    [SerializeField] private bool isLeftDoor;
    
    private bool _isDoorOpen;
    private bool _isInTrigger;
    private Vector3 _stupidPos = new Vector3(1000,1000,1000);
    
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
        if (!_isInTrigger) return;

        keyToPress.transform.LookAt(cam.transform);

        if (Keyboard.current.eKey.isPressed && !_isDoorOpen)
        {
            keyToPress.SetActive(false);
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        keyToPress.transform.position = _stupidPos;
        float targetY = isLeftDoor
            ? door.transform.eulerAngles.y - 90f
            : door.transform.eulerAngles.y + 90f;

        door.transform
            .DORotate(
                new Vector3(0, targetY, 0),
                openDoorTime
            )
            .SetEase(Ease.InOutCubic);

        _isDoorOpen = true;
    }
}