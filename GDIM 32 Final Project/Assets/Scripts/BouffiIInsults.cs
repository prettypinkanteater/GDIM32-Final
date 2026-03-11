using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BouffiIInsults : MonoBehaviour
{
    public List<string> insults = new List<string>();
    public TextMeshProUGUI insultText;
    public int insultSelect;

    public float timer;
    public float timerTimer = 10;
    void Start()
    {
        timer = timerTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            insultSelect = Random.Range(0, insults.Count);
            insultText.text = insults[insultSelect];
            timer = timerTimer;
        }
    }
}
