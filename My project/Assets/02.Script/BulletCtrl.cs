using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20.0f;
    public float force = 1500.0f;
    public Text elapsedTimeText;

    private Rigidbody rb;
    private bool timerStarted = false;
    private float elapsedTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);

        // 4초 후에 타이머 시작
        StartCoroutine(StartTimer(4f));
    }

    void Update()
    {
        // 타이머가 시작되고 Enemy 오브젝트가 아직 존재하는 동안에만 시간을 측정
        if (timerStarted && GameObject.FindWithTag("Enemy") != null)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            // Enemy 오브젝트를 파괴하고 난 후에 모든 Enemy 오브젝트가 사라졌는지 확인
            if (GameObject.FindWithTag("Enemy") == null)
            {
                // 시간 측정 종료
                timerStarted = false;
                elapsedTimeText.text = "모든 Enemy 오브젝트가 사라진 후 경과한 시간: " + elapsedTime + "초";
                Debug.Log("모든 Enemy 오브젝트가 사라진 후 경과한 시간: " + elapsedTime + "초");
            }
        }

        Destroy(gameObject);
    }

    IEnumerator StartTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        timerStarted = true;
    }
}
