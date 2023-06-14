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

        // 4�� �Ŀ� Ÿ�̸� ����
        StartCoroutine(StartTimer(4f));
    }

    void Update()
    {
        // Ÿ�̸Ӱ� ���۵ǰ� Enemy ������Ʈ�� ���� �����ϴ� ���ȿ��� �ð��� ����
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

            // Enemy ������Ʈ�� �ı��ϰ� �� �Ŀ� ��� Enemy ������Ʈ�� ��������� Ȯ��
            if (GameObject.FindWithTag("Enemy") == null)
            {
                // �ð� ���� ����
                timerStarted = false;
                elapsedTimeText.text = "��� Enemy ������Ʈ�� ����� �� ����� �ð�: " + elapsedTime + "��";
                Debug.Log("��� Enemy ������Ʈ�� ����� �� ����� �ð�: " + elapsedTime + "��");
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
