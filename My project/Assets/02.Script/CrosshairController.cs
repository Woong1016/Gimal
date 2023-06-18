using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    private void Start()
    {
        // 마우스 커서를 숨깁니다.
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        // 스크립트가 제거될 때 마우스 커서를 다시 표시합니다.
        Cursor.visible = true;
    }
}
