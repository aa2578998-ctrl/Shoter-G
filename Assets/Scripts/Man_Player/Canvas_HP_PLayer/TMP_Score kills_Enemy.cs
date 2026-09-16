using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class TMP_Scorekills_Enemy : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textBoss;

    public Spawn_EnemyAndBoss_Follow_Player scoreK;
    public TMP_HP_Player tMP_HP_Player;

    public int currentScore = 0;
    public int currentScoreBoss = 0;

    void Start()
    {
        UpdateText();
        BossUpdateText();

        scoreK = FindAnyObjectByType<Spawn_EnemyAndBoss_Follow_Player>();
        tMP_HP_Player = FindAnyObjectByType<TMP_HP_Player>();
    }

    private void UpdateText()
    {
        text.text = "Score kills enemy: " + currentScore;
    }

    public void BossUpdateText()
    {
        currentScoreBoss++;
        textBoss.text = "Score kills boss: " + currentScoreBoss;
    }


    public void ScoreKills()
    {
        if (!scoreK.BossActive)
        {
            scoreK.ScoreKill++;
        }

        tMP_HP_Player.currentHP += 5;
        scoreK.amountEAB--;

        currentScore++;

        tMP_HP_Player.UpdateHPtext();
        UpdateText();
    }
}
