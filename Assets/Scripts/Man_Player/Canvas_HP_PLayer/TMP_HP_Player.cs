using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TMP_HP_Player : MonoBehaviour
{
    public int HP = 100;
    public int currentHP = 0;

    public TextMeshProUGUI HPtext;


    public TextMeshProUGUI Cooldowm_Dashtext;
    public TextMeshProUGUI Cooldown_Pistoltext;
    public TextMeshProUGUI QuanityPatrons;
    public TextMeshProUGUI How_Kills_SpawnBoss;

    public Dash_Player2 dash_Player2;
    public Shot_Player shot_Player;

    public Spawn_EnemyAndBoss_Follow_Player SpawnBoss;

    void Start()
    {
        if (HPtext == null)
        {
            HPtext = GetComponent<TextMeshProUGUI>();
        }
        currentHP = HP;

        UpdateHPtext();
        CooldownShot();
    }

    void Update()
    {
        if (currentHP >= 101)
        {
            currentHP = 100;
            UpdateHPtext();
        }
        KillNoBosses();
    }

    public void UpdateHPtext()
    {
        HPtext.text = "HP: " + currentHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHPtext();
        if (currentHP <= 0)
        {
            Scene currenS = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currenS.name);
        }
    }

    public void CooldownDash()
    {
        Cooldowm_Dashtext.text = $"Dash cooldown: {dash_Player2.cooldownE}/2.5";
    }

    public void CooldownShot()
    {
        Cooldown_Pistoltext.text = $"Shot cooldowm: {shot_Player.corrutineTime}/0";
    }

    public void QuanityPatron()
    {
        QuanityPatrons.text = $"Quanity patron: {shot_Player.Spatrons}/{shot_Player.Patron}";
    }

    public void KillNoBosses()
    {
        How_Kills_SpawnBoss.text = $"Quanity kills the from bosses: {SpawnBoss.ScoreKill}/{SpawnBoss.AllKill}";
    }
}
