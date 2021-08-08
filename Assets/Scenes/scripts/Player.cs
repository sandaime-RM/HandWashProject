using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    //変数定義
    public float flap = 550f;
    public float scroll = 10f;
    float direction = 0f;
    int jump = 0;
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
            turn();
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;
            turn();
        }else 
        {
            direction = 0f;
            //direction2 = 0f;
        }

        if (Input.GetKeyDown("space") && jump < 2)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump ++;
        }

        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        jump = 0;
    }

    void turn() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 lscale = gameObject.transform.localScale;
        if ((lscale.x > 0 && moveHorizontal < 0)
            || (lscale.x < 0 && moveHorizontal > 0))
        {
            lscale.x *= -1;
            gameObject.transform.localScale = lscale;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
           SceneManager.LoadScene("ShoppingStreet");
        }
    }
}
