using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText, _bestScoreText;

    private int highscore;

    [SerializeField]
    private Image _livesImg;

    [SerializeField]
    private Text _gameOverText;

    [SerializeField]
    private Text _restartText;

    [SerializeField]
    private Sprite[] _liveSprites;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);

        _scoreText.text = "Score: " + 0;
        _bestScoreText.text = "Best: " + highscore;

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("GameManager is NULL!");
        }
    }

    public void UpdateScore(int PlayerScore)
    {
        _scoreText.text = "Score: " + PlayerScore.ToString();

        if (PlayerScore > highscore)
        {
            highscore = PlayerScore;
            if (highscore > 0)
            {
                PlayerPrefs.SetInt("HighScore", highscore);
            }
        }
    }

    public void UpdateLives(int currentLives)
    {
        if (currentLives > 0)
        {
            _livesImg.sprite = _liveSprites[currentLives];
        }
        if (currentLives == 0)
        {
            _livesImg.sprite = _liveSprites[currentLives];
            GameOverSequence();
        }
        else if (currentLives < 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _bestScoreText.text = "Best: " + highscore;
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ResumePlay()
    {
        _gameManager.ResumeGame();
    }

    public void BackToMainMenu()
    {
        _gameManager.ToMainMenu();
    }
}