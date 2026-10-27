using UnityEngine;

public class Sound_Object : MonoBehaviour
{
    public Sound_Manager sound_Manager;
    public AudioSource audioSettings;
    [SerializeField] public float audioSettings2;

    bool aS_Play = false;
    bool s_M__Clip = false;
    int s_M__Clip2 = 0;
    void Start()
    {
        sound_Manager = FindAnyObjectByType<Sound_Manager>();

        GetComponent<AudioSource>().generator = sound_Manager.audios[sound_Manager.ArreyAudio];
        audioSettings.volume = sound_Manager.VolumeAudio;

        aS_Play = false;
        s_M__Clip = sound_Manager.AudioCLips;
        audioSettings2 = audioSettings.clip.length - 0.2f;
        s_M__Clip2 = sound_Manager.ArreyAudio;
    }

    void Update()
    {
        if (s_M__Clip)
        {
            audioSettings.time = 2.2f;
            audioSettings2 = 3f;
            s_M__Clip = false;
        }
        if (s_M__Clip2 == 12)
        {
            audioSettings2 += 0.19f;
        }

        if (!aS_Play)
        {
            aS_Play = true;
            audioSettings.Play();
        }

        if (audioSettings.isPlaying)
        {
            if (audioSettings.time >= audioSettings2)
            {
                Destroy(gameObject);
            }
        }
    }
}
