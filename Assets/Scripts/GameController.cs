using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] Text resultText = null;
    [SerializeField] Canvas resultButton = null;


    // プレイヤー側で死亡した際にこの関数を呼ぶ
    public void FailureGame()
    {
        StartCoroutine(Result("GameOver"));
    }

    // プレイヤー側でクリアした際にこの関数を呼ぶ
    public void ClearGame()
    {
        StartCoroutine(Result("  Clear "));
    }


    IEnumerator Result(string message)
    {
        resultText.text = message;
        resultButton.enabled = true;
        yield break;
    }
}
