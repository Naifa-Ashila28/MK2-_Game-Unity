using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    // Gunakan string konstan agar tidak ada typo
    private const string MIXER_PARAMETER = "music";
    private const string SAVE_KEY = "musicVolume";

    private void Awake()
    {
        // Singleton Pattern: Memastikan hanya ada satu AudioManager
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Load volume saat game dimulai
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            LoadVolume();
        }
        else
        {
            // Jika belum ada save, gunakan nilai default dari slider
            SetMusicVolume();
        }
    }

    public void SetMusicVolume()
    {
        // PENGAMAN 1: Cek apakah slider ada di scene ini
        if (musicSlider == null) return;

        float volume = musicSlider.value;

        // Update Mixer
        UpdateMixer(volume);

        // Simpan ke memori
        PlayerPrefs.SetFloat(SAVE_KEY, volume);
    }

    private void LoadVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat(SAVE_KEY);

        // PENGAMAN 2: Update slider hanya jika slider ditemukan (Main Menu)
        if (musicSlider != null)
        {
            musicSlider.value = savedVolume;
        }

        // Tetap update suara mixer meskipun slider tidak ada (di Level 1, 2, dst)
        UpdateMixer(savedVolume);
    }

    private void UpdateMixer(float volume)
    {
        // Rumus logaritmik Unity Mixer: -80dB sampai 0dB
        // Mathf.Max digunakan agar tidak Log10(0) yang bikin error
        float dB = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20;
        myMixer.SetFloat(MIXER_PARAMETER, dB);
    }
}