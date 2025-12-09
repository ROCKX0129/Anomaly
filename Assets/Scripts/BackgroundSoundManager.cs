using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSoundManager : MonoBehaviour
{
    public static BackgroundSoundManager Instance { get; private set; }

    [Header("Background Music")]
    public AudioClip musicClip; // Drag your BGM track here (seamless loop recommended)

    [Header("Settings")]
    [Range(0f, 1f)] public float volume = 0.5f;
    public bool autoPlayOnStart = true; // Plays immediately when game starts
    public bool persistAcrossScenes = true; // Keeps playing between scenes

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton: Ensures only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Setup AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Loops forever (change to false for one-shot tracks)
        audioSource.volume = volume;
        audioSource.playOnAwake = false; // We'll control it manually

        // Apply initial clip
        SetTrack(musicClip);

        // Persist across scenes (music continues seamlessly)
        if (persistAcrossScenes)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Auto-play when game starts (after Awake/OnEnable)
        if (autoPlayOnStart && musicClip != null)
        {
            Play();
        }
    }

    /// <summary>
    /// Change the track at runtime (e.g., from UI buttons or GameManager)
    /// </summary>
    public void SetTrack(AudioClip newClip)
    {
        musicClip = newClip;
        if (audioSource != null && newClip != null)
        {
            audioSource.clip = newClip;
            if (audioSource.isPlaying)
                audioSource.Play(); // Restart with new clip
        }
    }

    /// <summary>
    /// Alter volume at runtime (e.g., from UI slider)
    /// </summary>
    public void SetVolume(float vol)
    {
        volume = Mathf.Clamp01(vol);
        if (audioSource != null)
            audioSource.volume = volume;
    }

    /// <summary>
    /// Play the current track (resumes if paused)
    /// </summary>
    public void Play()
    {
        if (audioSource != null && musicClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Pause the music (preserves position)
    /// </summary>
    public void Pause()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    /// <summary>
    /// Stop the music (resets to beginning)
    /// </summary>
    public void Stop()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    void OnEnable()
    {
        // Restart if disabled/enabled (e.g., scene reloads)
        if (autoPlayOnStart && musicClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}