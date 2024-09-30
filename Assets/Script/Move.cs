using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Header("移動速度")]
    private float _speed;
    // [SerializeField, Header("縦の画面サイズ(pixel)")]
    // private float _width;
    // [SerializeField, Header("横の画面サイズ(pixel)")]
    // private float _height;

    // private Vector3 ScreenMaxRight = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0, 1f));
    // private Vector3 ScreenMaxLeft  = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0, 1f));

    float MaxRight = 2.5f;
    float MaxLeft = -2.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    void _Move()
    {
        float moveX = 0f;
        float moveY = 0f;

        Vector2 Position = transform.position;

        if (Input.GetKey("left")) {
            if(transform.position.x > MaxLeft){
                moveX -= _speed;
            }
        }

        else if (Input.GetKey("right")) {
            if(transform.position.x < MaxRight){
                moveX += _speed;
            }
        }

        // if (Input.GetKey("up")) {
        //     moveY += _speed;
        // }

        // if (Input.GetKey("down")) {
        //     moveY -= _speed;
        // }

        if (moveX != 0f && moveY != 0f) {
            moveX /= 1.4f;
            moveY /= 1.4f;
        }

        Position.x += moveX;
        Position.y += moveY;

        transform.position = Position;
    }
}


