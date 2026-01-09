using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    
    [SerializeField] private Camera cam;
    
    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
