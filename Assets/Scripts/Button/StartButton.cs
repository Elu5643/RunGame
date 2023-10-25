using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // ƒ{ƒ^ƒ“UI‚ÅŽg‚¤ˆ×public
    public void OnClickStartButton()
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
        SceneManager.LoadScene("StageSelect");
    }
}
