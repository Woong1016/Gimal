using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    private void Start()
    {
        // ���콺 Ŀ���� ����ϴ�.
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        // ��ũ��Ʈ�� ���ŵ� �� ���콺 Ŀ���� �ٽ� ǥ���մϴ�.
        Cursor.visible = true;
    }
}
