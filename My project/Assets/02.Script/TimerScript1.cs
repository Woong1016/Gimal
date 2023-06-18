using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript1 : MonoBehaviour
{
    private float timer = 0.0f;
    private bool timerStarted = false;
    private float timerResult = 0.0f;
    public Text timerText; // UI(Text) ���
    public Text timerResultText; // 'Ending' ������ Ÿ�̸� ��� ���� ǥ���� UI(Text) ���

    void Update()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2"); // UI(Text) ��ҿ� Ÿ�̸� ���� ǥ���մϴ�.

            // Enemy 1 ������Ʈ�� ��� �ı��Ǹ� Ÿ�̸Ӹ� ����ϴ�.
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                timerStarted = false;
                timerResult = timer;
                PlayerPrefs.SetFloat("TimerResult", timerResult); // Ÿ�̸� ��� ���� �����մϴ�.
                SceneManager.LoadScene("Eneding 1"); // 'Ending' ������ ��ȯ�մϴ�.
            }
        }
    }

    void Start()
    {
        Invoke("StartTimer", 4.0f); // 4�� �ڿ� StartTimer �Լ��� ȣ���մϴ�.
    }

    void StartTimer()
    {
        timerStarted = true;
    }
}
