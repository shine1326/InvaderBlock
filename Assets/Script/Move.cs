using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Header("移動速度")]
    private float _speed;
    [SerializeField, Header("スタートポジション(x)")]
    private float _startPosX;
    [SerializeField, Header("スタートポジション(y)")]
    private float _startPosY;
    [SerializeField, Header("弾オブジェクト")]
    GameObject _Bullet;
    [SerializeField, Header("弾を発射するタイミング")]
    private float shootTime;

    private float shootCount;

    float MaxRight = 0.79f;
    float MaxLeft = -20.79f;

    void Start()
    {
        Vector2 _startPos;
        _startPos.x = _startPosX;
        _startPos.y = _startPosY;

        transform.position = _startPos;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        Shooting();
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

        else if(Input.GetKey("p")){
            SceneManager.LoadScene("PauseScene");
        }

        Position.x += moveX;
        Position.y += moveY;

        transform.position = Position;
    }

        private void Shooting()
    {
        shootCount += Time.deltaTime;
        if(shootCount < shootTime)  return;

        GameObject bulletObj = Instantiate(_Bullet);    //プレハブ化されたオブジェクトを生成する(クローンを生成)
        bulletObj.transform.position = transform.position;
        shootCount = 0.0f;
    }
}


