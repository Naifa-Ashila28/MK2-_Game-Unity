using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Pastikan ini ada agar TextMeshPro terbaca

public class Score : MonoBehaviour
{
    // Ini variabel untuk narik 'Score Text' di Inspector
    public TextMeshProUGUI myScoreText;

    private int scoreNumber;

    void Start()
    {
        // Skor mulai dari 0
        scoreNumber = 0;
        myScoreText.text = "Score : " + scoreNumber;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Sesuaikan dengan tag koin kamu (Coin)
        if (other.CompareTag("Coin"))
        {
            scoreNumber++; // Skor bertambah
            Destroy(other.gameObject); // Koin hilang

            // Update teks di layar
            myScoreText.text = "Score : " + scoreNumber;
        }
    }
}