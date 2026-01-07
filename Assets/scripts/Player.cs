using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float sensitivity = 200f;

    public AudioSource audioSource;
    public AudioClip[] footstepClips;

    private CharacterController _controller;
    private float _yRotation;

    private bool _footstepPlayed;
    private bool _doPlayFootstep;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!GameManager.Instance.playerCanMove) return;

        _yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);

        Vector3 direction = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) direction += transform.forward;
        if (Keyboard.current.sKey.isPressed) direction -= transform.forward;
        if (Keyboard.current.aKey.isPressed) direction -= transform.right;
        if (Keyboard.current.dKey.isPressed) direction += transform.right;

        _doPlayFootstep = direction != Vector3.zero;

        _controller.Move(direction.normalized * (velocity * Time.deltaTime));

        if (_doPlayFootstep)
            StartCoroutine(PlayFootstep());
    }

    IEnumerator PlayFootstep()
    {
        if (_footstepPlayed) yield break;

        _footstepPlayed = true;
        audioSource.clip = footstepClips[Random.Range(0, footstepClips.Length)];
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);
        _footstepPlayed = false;
    }
}