using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TMP_HP_Player : MonoBehaviour
{
    public int HP = 100;
    public int currentHP = 0;
    public TextMeshProUGUI HPtext;
    void Start()
    {
        if (HPtext == null)
        {
            HPtext = GetComponent<TextMeshProUGUI>();
        }
        currentHP = HP;

        UpdateHPtext();
    }
    private void UpdateHPtext()
    {
        HPtext.text = "HP: " + currentHP;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHPtext();
        if (currentHP < 0)
        {
            Scene currenS = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currenS.name);
        }
    }
}
