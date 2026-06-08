using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    // Ini untuk tempat memasukkan 3 tombol level kamu di Inspector nanti
    public Button[] buttons;

    void Start()
    {
        // 1. Level 1 selalu terbuka (bisa diklik)
        if (buttons.Length > 0 && buttons[0] != null)
        {
            buttons[0].interactable = true;
        }

        // 2. Cek apakah Level 2 sudah terbuka atau belum
        int level2Status = PlayerPrefs.GetInt("Level2Unlocked", 0);
        if (buttons.Length > 1 && buttons[1] != null)
        {
            if (level2Status == 1)
            {
                buttons[1].interactable = true; // Terbuka
            }
            else
            {
                buttons[1].interactable = false; // Terkunci (tombol jadi abu-abu)
            }
        }

        // 3. Cek apakah Level 3 sudah terbuka atau belum
        int level3Status = PlayerPrefs.GetInt("Level3Unlocked", 0);
        if (buttons.Length > 2 && buttons[2] != null)
        {
            if (level3Status == 1)
            {
                buttons[2].interactable = true; // Terbuka
            }
            else
            {
                buttons[2].interactable = false; // Terkunci (tombol jadi abu-abu)
            }
        }
    }

    // FITUR EMERGENCY: Klik kanan nama script di Inspector, lalu pilih "Reset Game Progress" kalau data error lagi
    [ContextMenu("Reset Game Progress")]
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Sip! Semua data progress level lama di laptop kamu sudah BERHASIL DIRESET!");
    }
}