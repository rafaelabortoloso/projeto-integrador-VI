using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }
}
