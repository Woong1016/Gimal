using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript1 : MonoBehaviour
{
    private float timer = 0.0f;
    private bool timerStarted = false;
    private float timerResult = 0.0f;
    public Text timerText; // UI(Text) 요소
    public Text timerResultText; // 'Ending' 씬에서 타이머 결과 값을 표시할 UI(Text) 요소

    void Update()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2"); // UI(Text) 요소에 타이머 값을 표시합니다.

            // Enemy 1 오브젝트가 모두 파괴되면 타이머를 멈춥니다.
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                timerStarted = false;
                timerResult = timer;
                PlayerPrefs.SetFloat("TimerResult", timerResult); // 타이머 결과 값을 저장합니다.
                SceneManager.LoadScene("Eneding 1"); // 'Ending' 씬으로 전환합니다.
            }
        }
    }

    void Start()
    {
        Invoke("StartTimer", 4.0f); // 4초 뒤에 StartTimer 함수를 호출합니다.
    }

    void StartTimer()
    {
        timerStarted = true;
    }
}
