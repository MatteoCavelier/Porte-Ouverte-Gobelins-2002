using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200f;

    private float _xRotation;

    void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}