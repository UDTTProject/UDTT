using UnityEngine;

public class DragBox : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rect selectionRect;
    private bool isSelecting = false;

    void OnGUI()
    {
        // �巡�� ���� ���� �ڽ� �׸���
        if (isSelecting)
        {
            // �巡�� ���⿡ ������� �ùٸ� �簢�� �׸���
            var rect = GetScreenRect(startPosition, endPosition);

            // ���� �ڽ� ��Ÿ�� ����
            GUI.color = new Color(0.5f, 0.8f, 1f, 0.3f);
            GUI.Box(rect, "");
            GUI.color = Color.white;
        }
    }

    void Update()
    {
        // ���콺 ���� ��ư ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            isSelecting = true;
        }

        // ���콺 ��ư ������ ���� �� ���� ������Ʈ
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
        }

        // ���콺 ��ư ������ ��
        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
        }
    }

    // �巡�� ����� ������� �ùٸ� �簢�� ����
    Rect GetScreenRect(Vector2 screenStart, Vector2 screenEnd)
    {
        // ���� ��ܿ��� ���� �ϴ����� �巡���� ����
        // ���� ��ܿ��� ���� �ϴ����� �巡���� �� ��� ó��
        screenStart.y = Screen.height - screenStart.y;
        screenEnd.y = Screen.height - screenEnd.y;

        Vector2 topLeft = Vector2.Min(screenStart, screenEnd);
        Vector2 bottomRight = Vector2.Max(screenStart, screenEnd);

        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }
}