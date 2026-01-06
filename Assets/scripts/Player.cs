using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float sensitivity = 200f;
    public AudioSource audioSource;
    public AudioClip[] footstepClips;

    private int stepIndex = 0;
    private bool _footstepPlayed;
    private bool _doPlayFootstep;

    private float _yRotation;

    void Update()
    {
        
        if (GameManager.Instance.playerCanMove)
        {
            _yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
            // TODO le son reste prendant le TP
            Vector3 direction = Vector3.zero;
            if (Keyboard.current.wKey.isPressed)
            {
               _doPlayFootstep = true;
                direction += Vector3.forward;
            }
            
            if (Keyboard.current.wKey.wasReleasedThisFrame)
            {
                _doPlayFootstep = false;
            }

            if (Keyboard.current.sKey.isPressed)
            {
                _doPlayFootstep = true;
                direction += Vector3.back;
            }
            
            if (Keyboard.current.sKey.wasReleasedThisFrame)
            {
                _doPlayFootstep = false;
            }

            if (Keyboard.current.aKey.isPressed)
            {
                _doPlayFootstep = true;
                direction += Vector3.left;
            }
            
            if (Keyboard.current.aKey.wasReleasedThisFrame)
            {
                _doPlayFootstep = false;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                _doPlayFootstep = true;
                direction += Vector3.right;
            }

            if (Keyboard.current.dKey.wasReleasedThisFrame)
            {
                _doPlayFootstep = false;
            }
            
            transform.Translate(direction.normalized * (velocity * Time.deltaTime), Space.Self);
        }

        if (_doPlayFootstep)
        {
            StartCoroutine(PlayFootstep());
        }
    }

    public IEnumerator PlayFootstep()
    {
        if (!_footstepPlayed)
        {
            _footstepPlayed = true;
            audioSource.clip = footstepClips[stepIndex];
            audioSource.Play();
            stepIndex = Random.Range(0, footstepClips.Length);
            yield return new WaitForSeconds(audioSource.clip.length + 0.1f);
            _footstepPlayed = false;
        }
    }
}