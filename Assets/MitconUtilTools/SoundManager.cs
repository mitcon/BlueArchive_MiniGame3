using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource bgmAudioSource;
    static AudioSource seAudioSource;

    public float BgmVolume
    {
        get { return bgmAudioSource.volume; }
        set { bgmAudioSource.volume = Mathf.Clamp01(value); }
    }

    public float SeVolume
    {
        get { return seAudioSource.volume; }
        set { seAudioSource.volume = Mathf.Clamp01(value); }
    }

    private void Start()
    {
        GameObject soundManager = CheckOtherSoundManager();
        bool checkResult = soundManager != null && soundManager != gameObject;

        if (checkResult) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        var sources = gameObject.GetComponents<AudioSource>();

        bgmAudioSource = sources[0].loop ? sources[0] : sources[1];
        seAudioSource = sources[0].loop ? sources[1] : sources[0];
    }

    private GameObject CheckOtherSoundManager()
    {
        return GameObject.FindGameObjectWithTag("SoundManager");
    }

    public static void PlayBgm(AudioClip clip)
    {
        bgmAudioSource.clip = clip;
        if (clip == null) return;

        bgmAudioSource.Play();
    }

    public static void PlaySe(AudioClip clip)
    {
        if (clip == null) return;

        seAudioSource.PlayOneShot(clip);
    }
}
