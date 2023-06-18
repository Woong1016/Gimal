using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public Text timerResultText; // 타이머 결과를 표시할 UI(Text) 요소

    void Start()
    {
        float timerResult = PlayerPrefs.GetFloat("TimerResult");
        timerResultText.text = "Timer Result: " + timerResult.ToString("F2"); // 결과 값을 UI(Text) 요소에 표시합니다.
    }
}
