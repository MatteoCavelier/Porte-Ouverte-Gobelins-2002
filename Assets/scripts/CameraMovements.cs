using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200f;

    private float _xRotation;

    void LateUpdate()
    {
        float mouseY = Mouse.current.delta.ReadValue().y;
        _xRotation -= mouseY * sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}