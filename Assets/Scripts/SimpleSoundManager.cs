using UnityEngine;

public class SimpleSoundManager : MonoBehaviour
{
    public static SimpleSoundManager Instance { get; private set; }

    [Header("Footstep Audio")]
    public AudioClip stepClip;  // Drag your LONG footstep loop here
    
    [Header("Settings")]
    [Range(0f, 1f)] public float volume = 0.8f;

    [Header("BGM Audio")]
    public AudioClip BGM;

    private AudioSource audioSource;
    private AudioSource BackgroundMusicSource;

    void Start()
    {
        BackgroundMusicSource.Play();
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = stepClip;
        audioSource.loop = true;        // REPEATS FOREVER
        audioSource.volume = volume;
        audioSource.playOnAwake = false;

        BackgroundMusicSource = gameObject.AddComponent<AudioSource>();
        BackgroundMusicSource.clip = BGM;
        BackgroundMusicSource.loop = true;
        BackgroundMusicSource.volume = volume;
        BackgroundMusicSource.playOnAwake = false;
    }

    /// <summary>
    /// Call from PlayerMovement: true = play/pause toggle based on movement
    /// </summary>
    public void SetFootstepsPlaying(bool isMoving)
    {
        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();     // RESUME/PLAY
        }
        else
        {
            audioSource.Pause();        // PAUSE INSTANTLY (preserves position)
        }
    }
}