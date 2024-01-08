using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TheWinner : MonoBehaviour
{
    public GameObject winnerend;
    public TextMeshProUGUI winner;

    public void winnerend_screen()
    {
        winnerend.SetActive(true);
    }
}
