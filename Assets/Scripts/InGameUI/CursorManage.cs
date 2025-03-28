using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static Texture2D hand;
    private static Texture2D original;

    void Start()
    {
        // �� ���� �ε� (��� UI ��ҿ��� ����)
        if (hand == null)
            hand = Resources.Load<Texture2D>("hand");

        if (original == null)
            original = Resources.Load<Texture2D>("original");

        // �⺻ Ŀ�� ����
        if (original != null)
            Cursor.SetCursor(original, Vector2.zero, CursorMode.Auto);
    }

    // UI ��ҿ� ���콺 ���� �� ȣ���
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hand != null)
            Cursor.SetCursor(hand, new Vector2(hand.width / 3, 0), CursorMode.Auto);
    }

    // UI ��ҿ��� ���콺 ���� �� ȣ���
    public void OnPointerExit(PointerEventData eventData)
    {
        if (original != null)
            Cursor.SetCursor(original, Vector2.zero, CursorMode.Auto);
    }

    // 2D ������Ʈ�� (Collider �ʿ�)
    void OnMouseOver()
    {
        if (hand != null)
            Cursor.SetCursor(hand, new Vector2(hand.width / 3, 0), CursorMode.Auto);
    }

    void OnMouseExit()
    {
        if (original != null)
            Cursor.SetCursor(original, Vector2.zero, CursorMode.Auto);
    }
}
