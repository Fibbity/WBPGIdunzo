using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public AudioSource mASource;
    public AudioSource wSource;
    public AudioSource lSource;
    public AudioClip bMusic;
    public AudioClip wMusic;
    public AudioClip lMusic;
    public TextMeshProUGUI gameOver;
    public GameObject gameOverText;
    
    [SerializeField] TextMeshProUGUI timerText;
    
    int score;

    float currentTime = 0f;
    float startingTime = 12f;

    //Getting Audio going, setting up timer, and somehow the score.
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        AudioSource mASource = GetComponent<AudioSource>();
        AudioSource wSource = GetComponent<AudioSource>();
        AudioSource lSource = GetComponent<AudioSource>();


        Invoke("ExecuteAfterTime", 2f);

        Invoke("GameOver", 12f);

        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }
    }


    // Name says it all
    public void ChangeScore (int gemValue)
    {
        score += gemValue;
        text.text = "X" + score.ToString();
    }

    // Playing the bgm
    void ExecuteAfterTime()
    {
        mASource.PlayOneShot(bMusic, 0.1f);
    }

   

    // Pops up the GameOver Text and allows restart
    void GameOver()
    {
        gameOverText.SetActive(true);

        if (score >= 10)
        {
            gameOver.text = "You win!";
            mASource.Pause();
            wSource.Play();
        } else
        {
            gameOver.text = "You lose!";
            mASource.Pause();
            lSource.Play();
        }
    }

}
