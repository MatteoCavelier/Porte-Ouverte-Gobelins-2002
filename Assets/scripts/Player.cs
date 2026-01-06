using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float sensitivity = 200f;

    private float _yRotation;

    void Update()
    {
        if (GameManager.Instance.playerCanMove)
        {
            _yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
            
            Vector3 direction = Vector3.zero;
            if (Keyboard.current.wKey.isPressed) direction += Vector3.forward;
            if (Keyboard.current.sKey.isPressed) direction += Vector3.back;
            if (Keyboard.current.aKey.isPressed) direction += Vector3.left;
            if (Keyboard.current.dKey.isPressed) direction += Vector3.right;
            
            transform.Translate(direction.normalized * (velocity * Time.deltaTime), Space.Self);
        }
    }
}