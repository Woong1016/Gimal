using UnityEngine;
using UnityEngine.UI;

public class TimerResultScript : MonoBehaviour
{
    public Text timerResultText; // 타이머 결과 값을 표시할 UI(Text) 요소

    void Start()
    {
        float timerResult = PlayerPrefs.GetFloat("TimerResult", 0.0f);
        timerResultText.text = timerResult.ToString("F2");
    }
}
