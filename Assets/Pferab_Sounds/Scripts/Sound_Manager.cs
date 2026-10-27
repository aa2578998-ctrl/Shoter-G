using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    static public AudioClip audioS1;
    static public AudioClip audioS2;
    static public AudioClip audioS3;
    static public AudioClip audioS4;
    static public AudioClip audioS5;
    static public AudioClip audioS6;
    static public AudioClip audioS7;
    static public AudioClip audioS8;
    static public AudioClip audioS9;
    static public AudioClip audioS10;
    public GameObject soundO;
    public GameObject ObjectParent;

    [SerializeField] public float VolumeAudio;
    [SerializeField] public int ArreyAudio = 0;
    [SerializeField] public bool AudioCLips = false;
    public AudioClip[] audios = { audioS1, audioS2, audioS3, audioS4, audioS5, audioS6, audioS7, audioS8, audioS9, audioS10 };


    public void Reproducte(int ChoiceAuSo_, GameObject Parent, float volume = 1, bool settingClip = false)
    {
        ArreyAudio = ChoiceAuSo_;
        VolumeAudio = volume;
        AudioCLips = settingClip;

        Instantiate(soundO, Parent.transform.position, Quaternion.identity);
    }
}
