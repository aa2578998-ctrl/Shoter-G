using UnityEngine;
using TMPro;
public class TMP_Scorekills_Enemy : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float currentScore = 0f;
    void Start()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        text.text = "Score kills enemy: " + currentScore;
    }
    public void ScoreKills(float score)
    {
        currentScore += score;
        UpdateText();
    }
}
