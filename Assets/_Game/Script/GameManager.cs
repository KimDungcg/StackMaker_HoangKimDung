using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public static GameManager instance;
    private bool isFinal;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        UIManager.instance.SetScore("Score: " + score);
    }
    private void Update()
    {
        if (isFinal)
        {
            UIManager.instance.FinalMap(true);
            return;
        }
    }
    public void SetPoint(int score)
    {
        this.score = score;
    }

    public int GetPoint()
    {
        return this.score;
    }

    public void AddScore()
    {
        score++;
        UIManager.instance.SetScore("Score: " + score);
    }
    public void NextLevel()
    {
        LevelManager.instance.NextLevel();
    }
    public void SetFinal(bool final)
    {
        this.isFinal = final;
    }
    public bool GetFinal()
    {
        return isFinal;
    }
}
