using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private Button continueButton;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    
    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        scoreSystem.EndTimer();
        int finalScore = scoreSystem.GetScore();
        gameOverText.text = $"Your Score: {finalScore}";

        gameOverDisplay.gameObject.SetActive(true);
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);

        continueButton.interactable = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        asteroidSpawner.enabled = true;

        gameOverDisplay.gameObject.SetActive(false);
    }
}
