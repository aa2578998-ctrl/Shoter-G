using Unity.Microsoft.GDK;
using UnityEngine;

public class Audio_Switced : MonoBehaviour
{
    public AudioSource Battle;
    public AudioSource Boss_battle;

    void Start()
    {
        Battle.Play();
    }

    public void AudioBoss2()
    {
        Battle.Pause();
        Boss_battle.Play();
    }

    public void AudioBattle1()
    {
        Boss_battle.Pause();
        Battle.Play();
    }
}
