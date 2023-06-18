using UnityEngine;
using UnityEngine.UI;

public class TimerResultScript : MonoBehaviour
{
    public Text timerResultText; // Ÿ�̸� ��� ���� ǥ���� UI(Text) ���

    void Start()
    {
        float timerResult = PlayerPrefs.GetFloat("TimerResult", 0.0f);
        timerResultText.text = timerResult.ToString("F2");
    }
}
