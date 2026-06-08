using UnityEngine;
using UnityEngine.UI; // Wajib ditambahkan untuk mengakses UI Image
using UnityEngine.SceneManagement; // Wajib ditambahkan untuk mengatur perpindahan scene dan membaca nama level

public class HealthManager : MonoBehaviour
{
    // Menggunakan static agar variabel ini global dan mudah diakses script lain
    public static int health;

    public Image[] hearts; // Array untuk menampung gambar hati di UI
    public Sprite fullHeart; // Gambar hati penuh
    public Sprite emptyHeart; // Gambar hati kosong

    private void Awake()
    {
        // Reset nyawa menjadi 3 setiap kali scene dimulai atau diulang
        health = 3;
    }

    void Update()
    {
        // 1. Ubah semua hati menjadi kosong dulu
        foreach (Image img in hearts)
        {
            if (img != null) // Pengaman agar tidak error jika ada slot array yang kosong
            {
                img.sprite = emptyHeart;
            }
        }

        // 2. Isi hati yang penuh sesuai jumlah health saat ini
        for (int i = 0; i < health && i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                hearts[i].sprite = fullHeart;
            }
        }

        // 3. LOGIKA KELINCI MATI (TIDAK MEMBUKA LEVEL BARU)
        if (health <= 0)
        {
            // Jika mati, langsung tendang player kembali ke Main Menu tanpa mengubah data PlayerPrefs
            if (Application.CanStreamedLevelBeLoaded("Main Menu"))
            {
                SceneManager.LoadScene("Main Menu");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}