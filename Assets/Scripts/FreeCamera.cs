using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 100.0f;
    [SerializeField] private float rotationSpeed = 100.0f;

    void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
    }

    private void Rotation()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * rotationSpeed;
        }
    }
}