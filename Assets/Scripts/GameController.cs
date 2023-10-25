using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] Text resultText = null;
    [SerializeField] Text pleaseText = null;


    // プレイヤー側で死亡した際にこの関数を呼ぶ
    public void FailureGame()
    {
        StartCoroutine(Result("GameOver"));
    }

    // プレイヤー側でクリアした際にこの関数を呼ぶ
    public void ClearGame()
    {
        StartCoroutine(Result("Clear"));
    }


    IEnumerator Result(string message)
    {
        resultText.text = message;
        pleaseText.enabled = true;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        SceneManager.LoadScene("StageSelect");
    }
}
