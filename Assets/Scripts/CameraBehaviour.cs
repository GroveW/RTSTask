using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float rotSpeed = 5.0f;

    [SerializeField]
    private InputAction cameraMovementAction;
    [SerializeField]
    private InputAction cameraRotationAction;


    void Start()
    {
        cameraMovementAction.Enable();
        cameraRotationAction.Enable();
        transform.position = new Vector3(0.0f, 5.0f, -5.0f);
    }

    private void Update()
    {
        HandleControlls();
    }

    private void HandleControlls()
    {
        var direction = cameraMovementAction.ReadValue<Vector2>().normalized;

        transform.Translate(new Vector3(direction.x, 0.0f, direction.y) * speed * Time.deltaTime);

        var rotation = cameraRotationAction.ReadValue<float>();

        transform.Rotate(Vector3.up * rotation * rotSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        cameraMovementAction.Disable();
        cameraRotationAction.Disable();
    }
}
