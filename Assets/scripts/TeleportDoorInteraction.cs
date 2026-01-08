using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportDoorInteraction : MonoBehaviour
{
    
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject keyToPress;
    [SerializeField] private GameObject door;
    [SerializeField] private float openDoorTime = 2f;
    [SerializeField] private float waitBeforeTeleporter = 2f;
    [SerializeField] private float blackScreenTime = 2f;
    [SerializeField] private bool isLeftDoor;
    [SerializeField] private GameObject teleportPosition;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject lightGroup;
    
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
            StartCoroutine(TeleportPlayer());
        }
    }

    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(waitBeforeTeleporter);
        blackScreen.SetActive(true);
        GameManager.Instance.playerCanMove = false;
        player.transform.position = teleportPosition.transform.position;
        lightGroup.SetActive(false);
        StartCoroutine(DoBlackScreen());
    }
    
    private IEnumerator DoBlackScreen()
    {
        yield return new WaitForSeconds(blackScreenTime);
        blackScreen.SetActive(false);
        GameManager.Instance.playerCanMove = true;
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