using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ReStartGame);
    }

    void ReStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
