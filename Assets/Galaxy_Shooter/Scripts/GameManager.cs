using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    [SerializeField]
    public GameObject pauseMenuPanel;

    private Animator _pauseMenuAnim;

    private void Start()
    {
        _pauseMenuAnim = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();

        if (_pauseMenuAnim == null)
        {
            Debug.Log("The _pauseMenuAnim is NULL!");
        }

        _pauseMenuAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            // TRY TO USE INTEGERS BECAUSE STRINGS ARE SLOWER!
            SceneManager.LoadScene(1); // Current game scene --> "Game"
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                pauseMenuPanel.SetActive(true);
                _pauseMenuAnim.SetBool("isPaused", true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
