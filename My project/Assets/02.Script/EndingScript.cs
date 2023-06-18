using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public Text timerResultText; // Ÿ�̸� ����� ǥ���� UI(Text) ���

    void Start()
    {
        float timerResult = PlayerPrefs.GetFloat("TimerResult");
        timerResultText.text = "Timer Result: " + timerResult.ToString("F2"); // ��� ���� UI(Text) ��ҿ� ǥ���մϴ�.
    }
}
