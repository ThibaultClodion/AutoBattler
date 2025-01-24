using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private Vector2 moveValue;
    private Vector3 rotationValue;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Move();
            Rotation();
        }
    }

    private void Move()
    {
        mainCamera.position += mainCamera.forward * moveValue.y * movementSpeed * Time.deltaTime;
        mainCamera.position += mainCamera.right * moveValue.x * movementSpeed * Time.deltaTime;
    }

    private void Rotation()
    {
        mainCamera.eulerAngles = rotationValue;
    }

    private void OnMove(InputValue moveValue)
    {
        this.moveValue = moveValue.Get<Vector2>();
    }

    private void OnRotate(InputValue rotateValue)
    {
        rotationValue = mainCamera.eulerAngles;
        rotationValue.x -= rotateValue.Get<Vector2>().y * rotationSpeed * Time.deltaTime;
        rotationValue.y += rotateValue.Get<Vector2>().x * rotationSpeed * Time.deltaTime;
    }
}
