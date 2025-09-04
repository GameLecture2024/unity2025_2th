using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] Button ReStartbutton;
    [SerializeField] Button QuitButton;

    private void OnEnable()
    {
        ReStartbutton.onClick.AddListener(Restart);
        QuitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        ReStartbutton.onClick.RemoveAllListeners();
        QuitButton.onClick.RemoveAllListeners();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();

        // application
    }

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
}
