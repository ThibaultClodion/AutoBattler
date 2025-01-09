using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private Vector2 moveValue;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mainCamera.position += mainCamera.forward * moveValue.y * movementSpeed * Time.deltaTime;
            mainCamera.position += mainCamera.right * moveValue.x * movementSpeed * Time.deltaTime;
        }
    }

    private void OnMove(InputValue moveValue)
    {
        this.moveValue = moveValue.Get<Vector2>();
    }

    private void OnRotate(InputValue rotateValue)
    {
        if (!Input.GetMouseButton(1)) return;

        Vector3 rot = mainCamera.eulerAngles;
        rot.x -= rotateValue.Get<Vector2>().y * rotationSpeed * Time.deltaTime;
        rot.y += rotateValue.Get<Vector2>().x * rotationSpeed * Time.deltaTime;

        mainCamera.eulerAngles = rot;
    }
}
