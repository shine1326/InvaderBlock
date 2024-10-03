using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//追加のライブラリ
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        // SceneInit();
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void SceneInit()
    {
        if(SceneManager.GetActiveScene().name == "StartScene") return;

        SceneManager.UnloadSceneAsync("GameScene", UnloadSceneOptions.None);
        SceneManager.UnloadSceneAsync("PauseScene", UnloadSceneOptions.None);
    }

    void Update()
    {
        
    }

    void StartGame()
    {
        Invoke(nameof(TimeAdjustment), 0.2f);
        Debug.Log("Start");
    }

    void TimeAdjustment(){
        SceneManager.LoadScene("GameScene");
    }
}
