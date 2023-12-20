using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public VoidEventSO gameOverEvent;
    public IntEventSO scoreUpEvent;
    public int curScore;
    public int bestScore;
    public GameObject player;
    public Text curScoreText;
    public Text bestScoreText;
    public AudioDefinition audioDefinition;
    public AudioClip scoreClip;
    public AudioClip gameOverClip;
    private void Awake()
    {
        audioDefinition = GetComponent<AudioDefinition>();
    }
    private void OnEnable()
    {
        gameOverEvent.OnEventRaised += ClearScore;
        scoreUpEvent.OnEventRaised += ScoreUp;
    }


    private void OnDisable()
    {
        gameOverEvent.OnEventRaised -= ClearScore;
        scoreUpEvent.OnEventRaised -= ScoreUp;
    }
    private void ClearScore()
    {
        audioDefinition.audioClip = gameOverClip;
        audioDefinition.PlayAudioClip();
        this.curScore = 0;
        UpdateScore();
    }

    private void ScoreUp(int score)
    {
        audioDefinition.audioClip = scoreClip;
        audioDefinition.PlayAudioClip();
        this.curScore += score;
        if (this.curScore > this.bestScore)
        {
            this.bestScore = this.curScore;
            player.GetComponent<PlayerController>().bestScore = this.bestScore;
            PlayerPrefs.SetInt("MyInt", this.bestScore);
            PlayerPrefs.Save();
        }
        UpdateScore();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.curScore = 0;
        this.bestScore = player.GetComponent<PlayerController>().bestScore;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        curScoreText.text = this.curScore.ToString();
        bestScoreText.text = this.bestScore.ToString();
    }
}
