using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    // �{�^��UI�Ŏg����public
    public void OnClickStage1Button()
    {
        StartCoroutine(ClickStart());
    }

    IEnumerator ClickStart()
    {
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene("Stage1");
    }
}
