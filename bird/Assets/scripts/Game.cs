using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    enum Game_Status
    {
        Ready,
        Ingame,
        Over
    }

    private Game_Status status;

    private Game_Status Status
    {
        get { return status; }
        set
        {
            this.status = value;
            UpdateUI();
        }
    }

    public GameObject panelready;
    public GameObject panelplay;
    public GameObject panelover;
    public Player Player;
    public Pipemanager Pipemanager;
    public int score;
    public int scorelast;
    public Text uiscore;
    public Text uiscore2;
    public Text uiscoremax;
    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
            this.uiscore.text = this.score.ToString();
            this.uiscore2.text = this.score.ToString();
            if (this.score > scorelast) {
                this.uiscoremax.text = this.score.ToString();
            }
            if (this.score == scorelast + 1)
            {
                this.uiscore.text = this.score.ToString() + "       好棒！比上次厉害啦！";
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        panelready.SetActive(true);
        this.Status = Game_Status.Ready;
        this.Player.OnDeath += Player_OnDeath;
        scorelast = score;
        this.Player.Onscore = OnPlayerScore;
    }

    public void OnPlayerScore(int score)
    {
        this.Score += score;
    }

    private void Player_OnDeath()
    {
        this.Status = Game_Status.Over;
        this.Pipemanager.StopRun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        this.panelready.SetActive(this.Status == Game_Status.Ready);
        this.panelplay.SetActive(this.Status == Game_Status.Ingame);
        this.panelover.SetActive(this.Status == Game_Status.Over);
    }

    public void StartGame()
    {
        this.Status = Game_Status.Ingame;
        Pipemanager.StartRun();
        Player.Fly();
    }

    public void Restart()
    {
        this.Status = Game_Status.Ready;
        this.Pipemanager.Init();
        this.Player.Init();
        scorelast = int.Parse(uiscoremax.text);
        Score = 0;
    }
    
}
