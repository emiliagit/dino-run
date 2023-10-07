using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float contadorScore = 0f;
    public TextMeshProUGUI highScoreText;
    private float highScore = 0f;
    void Start()
    {
        // Cargamos el puntaje máximo almacenado
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        UpdateHighScoreText();
    }


    void Update()
    {
        contadorScore += Time.deltaTime;
        scoreText.text = (contadorScore * 10).ToString("00000");

        if (contadorScore > highScore)
        {
            highScore = contadorScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + (highScore * 10).ToString("00000");
    }

}
