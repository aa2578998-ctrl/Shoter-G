using UnityEngine;
public class Game_Optimization : MonoBehaviour
{
    public Spawn_EnemyAndBoss_Follow_Player optimization; // Ссылка на другой скрипт
    [Header("Settings Quanity Enemy")]

    public float EnemyQuanity = 9f; // Колличесто допустимых врагов
    private void Start()
    {
        optimization = GetComponent<Spawn_EnemyAndBoss_Follow_Player>(); // Ищет компонент на объекте чтобы применить
    }
    void LateUpdate()
    {
        if (optimization.amountEAB > EnemyQuanity) // Если число врагов больше заданных придел
        {
            optimization.activated = false; // Отключает появление новых объектов
        }
        else // Если число врагов меньше заданного числа
        { 
        optimization.activated = true; // Включает спавн
        }
    }
}
