using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool starting = true;
    public bool playing = false;
    public int count = 50;
    public Action OnCoinHit;
    public Text scoreText;
    public GameObject startScreen, gameOverScreen, playScreen, winScreen;

    // Start is called before the first frame update
    void Start()
    {
        OnCoinHit += UpdateCount;
    }

    // Update is called once per frame
    void Update()
	{
        if (starting && Input.GetKeyDown(KeyCode.Space))
            Play();
	}

	private void UpdateCount() {

        count--;
        scoreText.text = count + " to go!";
        if (count == 0) Win();

	}

    public void Play() {

        starting = false;
        playing = true;
        startScreen.SetActive(false);
        playScreen.SetActive(true);
        scoreText.text = count + " to go!";

    }

    private void Win() {

        playing = false;
        playScreen.SetActive(false);
        winScreen.SetActive(true);

    }

    public void GameOver() {

        playing = false;
        playScreen.SetActive(false);
        gameOverScreen.SetActive(true);

    }

    public void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
