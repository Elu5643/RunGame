using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] AudioClip clickSE = null;
    AudioSource audioSource = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ƒ{ƒ^ƒ“UI‚ÅŽg‚¤ˆ×public
    public void OnClickStage1Button()
    {
        StartCoroutine(StageSelect("Stage1"));
    }

    public void OnClickBackMenuButton()
    {
        StartCoroutine(StageSelect("TitleScene"));
    }

    IEnumerator StageSelect(string stageSelect)
    {
        audioSource.PlayOneShot(clickSE);
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene(stageSelect);
    }
}
