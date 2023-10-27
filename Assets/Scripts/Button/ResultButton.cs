using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    // �{�^��UI�Ŏg����public
    public void OnClickRetryButton()
    {
        StartCoroutine(Result("Stage1"));
    }
    
    public void OnClickReturnButton()
    {
        StartCoroutine(Result("StageSelect"));
    }

    IEnumerator Result(string stageSelect)
    {
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene(stageSelect);
    }
}
