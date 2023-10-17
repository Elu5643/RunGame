using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;

    float speed = 5.0f;     // Playerの移動速度
    int gravitySwitch = 0;  // 重力の切り替え
    bool isJump = false;    // ジャンプしているか
    float jumpPower = 0;    // ジャンプ力

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gravitySwitch++;
            if (gravitySwitch % 2 == 0)
            {
                rb2D.gravityScale = 1000;
            }
            else if (gravitySwitch % 2 == 1)
            {
                rb2D.gravityScale = -1000;
            }
        }

        if (isJump == true) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            rb2D.gravityScale = 5f;
            jumpPower = 15f;
            isJump = false;
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            rb2D.gravityScale = -5f;
            jumpPower = -15f;
            isJump = false;
        }
    }
}
