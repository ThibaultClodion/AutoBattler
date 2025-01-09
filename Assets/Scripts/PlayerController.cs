using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform cameraRotator;
    [SerializeField] private float cameraZoomSpeed;
    [SerializeField] private float cameraRotationSpeed;

    private float zoomValue;
    private float rotateValue;

    // Update is called once per frame
    void Update()
    {
        mainCamera.position += mainCamera.forward * zoomValue * cameraZoomSpeed * Time.deltaTime;
        cameraRotator.Rotate(new Vector3(0, -rotateValue * cameraRotationSpeed * Time.deltaTime, 0));
    }

    private void OnZoom(InputValue zoomValue)
    {
        this.zoomValue = zoomValue.Get<float>();
    }

    private void OnRotate(InputValue rotateValue)
    {
        this.rotateValue = rotateValue.Get<float>();
    }
}
