using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMenu : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(startTimer());
    }

    IEnumerator startTimer()
    {
            
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Menu");
    }
}
