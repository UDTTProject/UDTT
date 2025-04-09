using UnityEngine;

public class MoveCharactor : MonoBehaviour
{
    public float moveSpeed = 10f; // 카메라 이동 속도
    public float edgeThreshold = 10f; // 화면 가장자리 감지 범위 (픽셀 단위)
    public float zoomSpeed = 5f; // 줌 속도
    public float minZoom = 2f; // 최소 줌 값
    public float maxZoom = 10f; // 최대 줌 값

    private Vector2 screenSize;
    private Camera cam;
    private Vector2 ScreenCenter;

    void Start()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        cam = Camera.main;
        ScreenCenter = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x <= edgeThreshold) // 왼쪽 가장자리
        {
            direction.x = (float)(mousePosition.x * 0.005);
            Debug.Log("-x 이동: " + mousePosition.x + ", " + direction.x);
        }
        else if (mousePosition.x >= screenSize.x - edgeThreshold) // 오른쪽 가장자리
        {
            direction.x = (float)(mousePosition.x * 0.005 - 3);
            Debug.Log("x 이동: " + mousePosition.x + ", " + direction.x);
        }

        if (mousePosition.y <= edgeThreshold) // 아래쪽 가장자리
        {
            direction.y = (float)(mousePosition.y * 0.005);
            Debug.Log("-y 이동: " + mousePosition.y + ", " + direction.y);
        }
        else if (mousePosition.y >= screenSize.y - edgeThreshold) // 위쪽 가장자리
        {
            direction.y = (float)(mousePosition.y * 0.005 - 1);
            Debug.Log("y 이동: " + mousePosition.y + ", " + direction.y);
        }

        transform.position += direction * moveSpeed * Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }
}