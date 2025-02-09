using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 0.5f;    // Speed for dragging movement
    public float zoomSpeed = 5f;      // Speed for zooming
    public float minZoom = 5f;        // Minimum zoom limit
    public float maxZoom = 50f;       // Maximum zoom limit

    private Vector3 lastMousePosition;
    private bool isDragging = false;

    void Update()
    {
#if UNITY_EDITOR
            HandleMouseInput();
#else
            HandleTouchInput();
#endif
    }

    void HandleMouseInput()
    {
        // Camera movement with right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x * moveSpeed * Time.deltaTime, 0, -delta.y * moveSpeed * Time.deltaTime);
            transform.Translate(move, Space.World);
            lastMousePosition = Input.mousePosition;
        }

        // Zoom using mouse scroll
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastMousePosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 delta = (Vector3)touch.position - lastMousePosition;
                Vector3 move = new Vector3(-delta.x * moveSpeed * Time.deltaTime, -delta.y * moveSpeed * Time.deltaTime, 0);
                transform.Translate(move, Space.Self);
                lastMousePosition = touch.position;
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            float prevDistance = (touch1.position - touch1.deltaPosition - (touch2.position - touch2.deltaPosition)).magnitude;
            float currentDistance = (touch1.position - touch2.position).magnitude;

            float zoomChange = (currentDistance - prevDistance) * zoomSpeed * Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomChange, minZoom, maxZoom);
        }
    }
}