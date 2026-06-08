using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ditambahkan untuk membaca nama level aktif

public class FinishPoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool isLastLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

            if (coins.Length > 0)
            {
                Debug.Log("Koin belum habis! Sisa koin: " + coins.Length);
            }
            else
            {
                // === SISTEM BUKA KUNCI LEVEL SAAT MENANG/FINISH ===
                string currentScene = SceneManager.GetActiveScene().name;

                // Kalau menang di Level 1, buka Level 2
                if (currentScene == "Level 1" || currentScene == "Level1")
                {
                    PlayerPrefs.SetInt("Level2Unlocked", 1);
                }
                // Kalau menang di Level 2, buka Level 3
                else if (currentScene == "Level 2" || currentScene == "Level2")
                {
                    PlayerPrefs.SetInt("Level3Unlocked", 1);
                }

                // Simpan data progress ke memori laptop
                PlayerPrefs.Save();
                // ==================================================

                SceneController sceneController = Object.FindFirstObjectByType<SceneController>();

                if (isLastLevel)
                {
                    Debug.Log("Game Tamat! Pindah ke WinScene.");
                    sceneController.LoadScene("WinScene");
                }
                else
                {
                    Debug.Log("Level Selesai! Lanjut ke level berikutnya.");
                    sceneController.NextLevel();
                }
            }
        }
    }
}