using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private CharacterController controller;

    [Header("Camera")]
    public Transform cameraTransform;
    public float zoomFOV = 30f;
    public float zoomSpeed = 10f;
    private float normalFOV;
    private Camera cam;

    [Header("Magnifying Glass")]
    public GameObject magnifyingGlass;
    private bool isZooming = false;

    [Header("Raycast Interaction")]
    public float interactDistance = 50f;
    public LayerMask interactableLayer;
    public int raysPerAxis = 3;
    public float rayOffset = 0.05f;

    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = cameraTransform.GetComponent<Camera>();
        normalFOV = cam.fieldOfView;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (magnifyingGlass != null)
            magnifyingGlass.SetActive(false);
    }

    void Update()
    {
        // Stop the player and camera movement if the game is paused
        if (PauseManager.instance != null && PauseManager.instance.isPaused)
            return;

        MovePlayer();
        MouseLook();
        HandleZoom();
        HandleRaycastInteraction();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool isMoving = (x != 0 || z != 0);

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        SimpleSoundManager.Instance?.SetFootstepsPlaying(isMoving);
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleZoom()
    {
        if (Input.GetMouseButton(1))
            isZooming = true;
        else
            isZooming = false;

        float targetFOV = isZooming ? zoomFOV : normalFOV;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

        if (magnifyingGlass != null)
            magnifyingGlass.SetActive(isZooming);
    }

    void HandleRaycastInteraction()
    {
        if (isZooming && Input.GetMouseButtonDown(0))
        {
            for (int x = -raysPerAxis; x <= raysPerAxis; x++)
            {
                for (int y = -raysPerAxis; y <= raysPerAxis; y++)
                {
                    Vector3 viewportPoint = new Vector3(
                        0.5f + x * rayOffset,
                        0.5f + y * rayOffset,
                        0f
                    );

                    Ray ray = cam.ViewportPointToRay(viewportPoint);
                    if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactableLayer))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
