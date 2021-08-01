using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //変数定義
    public float flap = 550f;
    public float scroll = 10f;
    float direction = 0f;
    bool jump = false;
    Rigidbody2D rb2d;


    // Use this for initialization
    void Start () {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update () {

        //キーボード操作
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1f;
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;
        }else 
        {
            direction = 0f;
            //direction2 = 0f;
        }

        if (Input.GetKeyDown("space") && !jump)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump = true
        }

        // //スマホ操作
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     //画面右半分をタッチしていたら
        //     if(touch.position.x > Screen.width * 0.5f)
        //     {
        //         direction = 1f;
        //     //画面左半分をタッチしていたら
        //     }else if (touch.position.x < Screen.width * 0.5f)
        //     {
        //         direction = -1f;
        //     }
        //     else
        //     {
        //         direction = 0f;
        //     }
        // }

        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
    }
}
