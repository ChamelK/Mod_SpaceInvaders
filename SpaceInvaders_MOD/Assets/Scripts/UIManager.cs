using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public Text highscoreText;
    public int highscore;

    public Text coinsText;

    public Text waveText;
    public int wave;

    public Image[] lifeSprites;
    public Image healthBar;

    public Sprite[] healthBars;

    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static void UpdateLives(int one)
    {
        foreach (Image i in instance.lifeSprites)
            i.color = instance.inactive;

        for (int i = 0; i < one; i++)
        {
            instance.lifeSprites[i].color = instance.active;
        }

    }

    public static void UpdateHealthBar(int h)
    {
        instance.healthBar.sprite = instance.healthBars[h];
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("000,000");
    }

    public static void UpdateHighScore()
    {
        //TODO
    }
    public static void UpdateWave()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }
    public static void UpdateCoins()
    {
        //TODO
    }
}
