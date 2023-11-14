using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] Button startButton = null;

    // Start is called before the first frame update
    void Start()
    {
        GameSoundManager.Instance.PlayBGM(GameSoundManager.BGMType.Title);
        startButton.onClick.AddListener(OnClickStartButton);
    }

    // ƒ{ƒ^ƒ“UI‚ÅŽg‚¤ˆ×public
    void OnClickStartButton()
    {
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton()
    {
        GameSoundManager.Instance.PlaySE(GameSoundManager.SEType.Click);
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene("StageSelect");
    }

}
