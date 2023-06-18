using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAdvice : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("Advice");
    }
}