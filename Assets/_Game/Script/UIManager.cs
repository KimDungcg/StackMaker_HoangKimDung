using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI ScoreTxt;
    [SerializeField] private GameObject final;
    public static UIManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void SetScore(string scr)
    {
        if (ScoreTxt != null)
        {
            ScoreTxt.text = scr;
        }
    }
    public void FinalMap(bool isShow)
    {
        if (final)
        {
            final.SetActive(isShow);
        }
    }
}
