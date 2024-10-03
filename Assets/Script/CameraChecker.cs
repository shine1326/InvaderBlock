using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChecker : MonoBehaviour
{
    enum Mode
    {
        None,
        Render,
        RenderOut,
    }

    private Mode mode;
    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    private void OnWillRenderObject()   //カメラに映った場合に呼ばれる
    {
        Debug.Log("camera");
        if(Camera.current.name == "GameCamera"){   //中でもメインカメラ(ゲームカメラ)に限定している
            mode = Mode.Render;
        }
    }

    private void Dead()
    {
        if(mode == Mode.RenderOut){
            Debug.Log("out");
            Destroy(gameObject);
        }else if(mode == Mode.Render){  /*どちらにせよ画面外という判定にして上のOnWillRenderObject()で上書きする
                                        そして再びDead()が呼ばれた際Renderに上書きされなかったら破壊する*/
            Debug.Log("in");
            mode = Mode.RenderOut;          
        }
    }
}
